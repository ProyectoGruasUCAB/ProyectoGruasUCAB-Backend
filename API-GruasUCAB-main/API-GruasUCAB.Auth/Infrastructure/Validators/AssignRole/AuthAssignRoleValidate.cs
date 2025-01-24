namespace API_GruasUCAB.Auth.Infrastructure.Validators.AssignRole
{
     public class AssignRoleValidator : IService<AssignRoleRequestDTO, AssignRoleResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly HeadersToken _headersToken;
          private readonly IKeycloakRepository _keycloakRepository;

          public AssignRoleValidator(IHttpClientFactory httpClientFactory, HeadersToken headersToken, IKeycloakRepository keycloakRepository)
          {
               _httpClientFactory = httpClientFactory;
               _headersToken = headersToken;
               _keycloakRepository = keycloakRepository;
          }

          public async Task<AssignRoleResponseDTO> Execute(AssignRoleRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();
               //   Headers Token
               var token = _headersToken.GetToken();
               _headersToken.SetAuthorizationHeader(client);

               try
               {
                    //   Introspect Token
                    var (_, role, email) = await _keycloakRepository.IntrospectTokenAsync(client, token);

                    // Validar si el email coincide
                    if (!string.Equals(email, request.UserEmail, StringComparison.OrdinalIgnoreCase))
                    {
                         return new AssignRoleResponseDTO { Success = false, Message = "Email does not match.", Time = DateTime.UtcNow, UserEmail = request.UserEmail };
                    }

                    // Validar si el rol puede asignar el rol objetivo
                    if (!RoleValidator.CanPerformAction(role, request.RoleName))
                    {
                         throw new UnauthorizedAccessException("You do not have permissions to assign this type of role.");
                    }

                    //   Search ID Client
                    var clientId = await _keycloakRepository.GetClientIdAsync(client);
                    if (string.IsNullOrEmpty(clientId))
                    {
                         return new AssignRoleResponseDTO { Success = false, Message = "The client ID could not be found.", Time = DateTime.UtcNow, UserEmail = request.UserEmail, RoleName = request.RoleName, EmailAssignedRole = request.EmailAssignedRole };
                    }

                    //   RoleName => RoleID
                    var roleId = await _keycloakRepository.GetRoleAsync(client, clientId, request.RoleName);
                    if (string.IsNullOrEmpty(roleId))
                    {
                         return new AssignRoleResponseDTO { Success = false, Message = "The client role could not be found.", Time = DateTime.UtcNow, UserEmail = request.UserEmail, RoleName = request.RoleName, EmailAssignedRole = request.EmailAssignedRole };
                    }

                    //   Email => UserID
                    var (userId, _) = await _keycloakRepository.GetUserByEmailAsync(client, request.EmailAssignedRole, string.Empty);

                    //   Verify Role
                    if (await _keycloakRepository.VerifyRoleAssignmentAsync(client, userId, clientId, roleId))
                    {
                         return new AssignRoleResponseDTO { Success = false, Message = "The user already has a role assigned.", Time = DateTime.UtcNow, UserEmail = request.UserEmail, RoleName = request.RoleName, EmailAssignedRole = request.EmailAssignedRole };
                    }

                    //   Assign Role
                    if (!await _keycloakRepository.AssignRoleAsync(client, userId, clientId, roleId, request.RoleName))
                    {
                         return new AssignRoleResponseDTO { Success = false, Message = "The role could not be assigned to the user.", Time = DateTime.UtcNow, UserEmail = request.UserEmail, RoleName = request.RoleName, EmailAssignedRole = request.EmailAssignedRole };
                    }

                    //   Verify Role Assignment
                    if (!await _keycloakRepository.VerifyRoleAssignmentAsync(client, userId, clientId, roleId))
                    {
                         return new AssignRoleResponseDTO { Success = false, Message = "The role was not assigned correctly.", Time = DateTime.UtcNow, UserEmail = request.UserEmail, RoleName = request.RoleName, EmailAssignedRole = request.EmailAssignedRole };
                    }

                    return new AssignRoleResponseDTO
                    {
                         Success = true,
                         Message = "Role assigned successfully",
                         Time = DateTime.UtcNow,
                         UserEmail = request.UserEmail,
                         EmailAssignedRole = request.EmailAssignedRole,
                         RoleName = request.RoleName
                    };
               }
               catch (UnauthorizedAccessException ex)
               {
                    return new AssignRoleResponseDTO { Success = false, Message = $"Unauthorized access: {ex.Message}", Time = DateTime.UtcNow, UserEmail = request.UserEmail, RoleName = request.RoleName, EmailAssignedRole = request.EmailAssignedRole };
               }
               catch (Exception ex)
               {
                    return new AssignRoleResponseDTO { Success = false, Message = ex.Message, Time = DateTime.UtcNow, UserEmail = request.UserEmail, RoleName = request.RoleName, EmailAssignedRole = request.EmailAssignedRole };
               }
          }
     }
}