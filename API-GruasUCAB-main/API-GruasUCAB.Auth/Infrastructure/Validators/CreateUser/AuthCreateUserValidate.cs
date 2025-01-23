namespace API_GruasUCAB.Auth.Infrastructure.Validators.CreateUser
{
     public class AuthCreateUserValidate : IService<CreateUserRequestDTO, CreateUserResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly HeadersToken _headersToken;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IService<DeleteUserRequestDTO, DeleteUserResponseDTO> _deleteUserService;
          private readonly IService<AssignRoleRequestDTO, AssignRoleResponseDTO> _assignRoleService;
          private readonly EmailProcessor _emailProcessor;
          private readonly INewWorkerRepository _newWorkerRepository;
          private readonly INewProviderRepository _newProviderRepository;
          private readonly INewDriverRepository _newDriverRepository;

          public AuthCreateUserValidate(
              IHttpClientFactory httpClientFactory,
              HeadersToken headersToken,
              IKeycloakRepository keycloakRepository,
              IService<DeleteUserRequestDTO, DeleteUserResponseDTO> deleteUserService,
              IService<AssignRoleRequestDTO, AssignRoleResponseDTO> assignRoleService,
              EmailProcessor emailProcessor,
              INewWorkerRepository newWorkerRepository,
              INewProviderRepository newProviderRepository,
              INewDriverRepository newDriverRepository)
          {
               _httpClientFactory = httpClientFactory;
               _headersToken = headersToken;
               _keycloakRepository = keycloakRepository;
               _deleteUserService = deleteUserService;
               _assignRoleService = assignRoleService;
               _emailProcessor = emailProcessor;
               _newWorkerRepository = newWorkerRepository;
               _newProviderRepository = newProviderRepository;
               _newDriverRepository = newDriverRepository;
          }

          public async Task<CreateUserResponseDTO> Execute(CreateUserRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();

               try
               {
                    // Headers Token
                    var token = _headersToken.GetToken();
                    _headersToken.SetAuthorizationHeader(client);

                    // Validate WorkplaceId ^ Position
                    if ((request.NameRole == "Trabajador" || request.NameRole == "Conductor" || request.NameRole == "Proveedor") && !request.WorkplaceId.HasValue)
                    {
                         return new CreateUserResponseDTO { Success = false, Message = "WorkplaceId is required for the specified role.", Time = DateTime.UtcNow, UserEmail = request.UserEmail };
                    }
                    if (request.NameRole == "Trabajador" && string.IsNullOrEmpty(request.Position))
                    {
                         return new CreateUserResponseDTO { Success = false, Message = "Position is required for the role Trabajador.", Time = DateTime.UtcNow, UserEmail = request.UserEmail };
                    }

                    // Password Temporary
                    var password = PasswordGenerator.GeneratePassword();

                    // Create User
                    var userCreated = await _keycloakRepository.CreateUserAsync(client, request.EmailToCreate, password);
                    if (!userCreated)
                    {
                         return new CreateUserResponseDTO { Success = false, Message = "Error creating user", Time = DateTime.UtcNow, UserEmail = request.UserEmail, EmailToCreate = request.EmailToCreate };
                    }

                    // Email => UserID
                    var (userIdString, _) = await _keycloakRepository.GetUserByEmailAsync(client, request.EmailToCreate, string.Empty);
                    if (!Guid.TryParse(userIdString, out var userId))
                    {
                         return new CreateUserResponseDTO { Success = false, Message = "Error retrieving user ID", Time = DateTime.UtcNow, UserEmail = request.UserEmail, EmailToCreate = request.EmailToCreate };
                    }

                    // Assign Role
                    var assignRoleResponse = await _assignRoleService.Execute(new AssignRoleRequestDTO
                    {
                         EmailAssignedRole = request.EmailToCreate,
                         RoleName = request.NameRole,
                         UserEmail = request.UserEmail
                    });

                    if (!assignRoleResponse.Success)
                    {
                         var deleteUserResponse = await _deleteUserService.Execute(new DeleteUserRequestDTO { UserEmail = request.UserEmail, EmailToDelete = request.EmailToCreate });
                         if (!deleteUserResponse.Success)
                         {
                              return new CreateUserResponseDTO { Success = false, Message = "Error assigning role and deleting user", Time = DateTime.UtcNow, UserEmail = request.UserEmail, EmailToCreate = request.EmailToCreate };
                         }
                         return new CreateUserResponseDTO { Success = false, Message = "Error assigning role", Time = DateTime.UtcNow, UserEmail = request.UserEmail };
                    }

                    // Save on role
                    await SaveUserByRole(request, userId);

                    // Send Email
                    var emailResponse = await _emailProcessor.SendEmailAsync(request.EmailToCreate, "Cuenta creada", "new-user.ftl", new Dictionary<string, string> { { "password", password } });
                    if (!emailResponse.Success)
                    {
                         var deleteUserResponse = await _deleteUserService.Execute(new DeleteUserRequestDTO { EmailToDelete = request.EmailToCreate });
                         if (!deleteUserResponse.Success)
                         {
                              return new CreateUserResponseDTO { Success = false, Message = "Error sending email and deleting user", Time = DateTime.UtcNow, UserEmail = request.UserEmail, EmailToCreate = request.EmailToCreate };
                         }
                         return new CreateUserResponseDTO { Success = false, Message = emailResponse.Message, Time = DateTime.UtcNow, UserEmail = request.UserEmail };
                    }

                    Console.WriteLine($"\n\nGenerated password: {password}\n\n");
                    return new CreateUserResponseDTO
                    {
                         Success = true,
                         Message = "User created successfully",
                         EmailToCreate = request.EmailToCreate,
                         Time = DateTime.UtcNow,
                         UserEmail = request.UserEmail,
                         NameRole = request.NameRole,
                         WorkplaceId = request.WorkplaceId
                    };
               }
               catch (UnauthorizedAccessException ex)
               {
                    return new CreateUserResponseDTO
                    {
                         Success = false,
                         Message = $"Unauthorized access: {ex.Message}",
                         Time = DateTime.UtcNow,
                         UserEmail = request.UserEmail
                    };
               }
               catch (Exception ex)
               {
                    return new CreateUserResponseDTO
                    {
                         Success = false,
                         Message = ex.Message,
                         Time = DateTime.UtcNow,
                         UserEmail = request.UserEmail
                    };
               }
          }

          private async Task SaveUserByRole(CreateUserRequestDTO request, Guid userId)
          {
               switch (request.NameRole)
               {
                    case "Trabajador":
                         var worker = new NewWorker
                         {
                              WorkerId = userId,
                              DepartmentId = request.WorkplaceId ?? Guid.Empty,
                              Position = request.Position ?? string.Empty
                         };
                         await _newWorkerRepository.Add(worker);
                         break;
                    case "Proveedor":
                         var provider = new NewProvider
                         {
                              ProviderId = userId,
                              SupplierId = request.WorkplaceId ?? Guid.Empty
                         };
                         await _newProviderRepository.Add(provider);
                         break;
                    case "Conductor":
                         var driver = new NewDriver
                         {
                              DriverId = userId,
                              SupplierId = request.WorkplaceId ?? Guid.Empty
                         };
                         await _newDriverRepository.Add(driver);
                         break;
                    default:
                         throw new ArgumentException("Invalid role specified");
               }
          }
     }
}