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

          public AuthCreateUserValidate(IHttpClientFactory httpClientFactory, HeadersToken headersToken, IKeycloakRepository keycloakRepository, IService<DeleteUserRequestDTO, DeleteUserResponseDTO> deleteUserService, IService<AssignRoleRequestDTO, AssignRoleResponseDTO> assignRoleService, EmailProcessor emailProcessor)
          {
               _httpClientFactory = httpClientFactory;
               _headersToken = headersToken;
               _keycloakRepository = keycloakRepository;
               _deleteUserService = deleteUserService;
               _assignRoleService = assignRoleService;
               _emailProcessor = emailProcessor;
          }

          public async Task<CreateUserResponseDTO> Execute(CreateUserRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();

               try
               {
                    //   Headers Token
                    var token = _headersToken.GetToken();
                    _headersToken.SetAuthorizationHeader(client);

                    //   Introspect Token
                    var (UserEmail, role, email) = await _keycloakRepository.IntrospectTokenAsync(client, token);

                    if (!string.Equals(email, request.UserEmail, StringComparison.OrdinalIgnoreCase))
                    {
                         return new CreateUserResponseDTO { Success = false, Message = "Email does not match.", Time = DateTime.UtcNow, UserEmail = request.UserEmail };
                    }

                    // Validate Role
                    if (!RoleValidator.CanPerformAction(role, request.NameRole))
                    {
                         throw new UnauthorizedAccessException("You do not have permissions to create this type of user.");
                    }

                    //   Password Temporary
                    var password = PasswordGenerator.GeneratePassword();

                    //   Create User
                    var userCreated = await _keycloakRepository.CreateUserAsync(client, request.EmailToCreate, password);
                    if (!userCreated)
                    {
                         return new CreateUserResponseDTO { Success = false, Message = "Error creating user", Time = DateTime.UtcNow, UserEmail = request.UserEmail, EmailToCreate = request.EmailToCreate };
                    }

                    //   Email => UserID
                    var (userId, _) = await _keycloakRepository.GetUserByEmailAsync(client, request.EmailToCreate, string.Empty);

                    //   Assign Role
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

                    //   Send Email
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
                         NameRole = request.NameRole
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
     }
}