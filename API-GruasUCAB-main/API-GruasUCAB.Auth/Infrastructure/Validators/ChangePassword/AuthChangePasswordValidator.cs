namespace API_GruasUCAB.Auth.Infrastructure.Validators.ChangePassword
{
     public class AuthChangePasswordValidator : IService<ChangePasswordRequestDTO, ChangePasswordResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly HeadersToken _headersToken;
          private readonly IKeycloakRepository _keycloakRepository;

          public AuthChangePasswordValidator(IHttpClientFactory httpClientFactory, IConfiguration configuration, HeadersToken headersToken, IKeycloakRepository keycloakRepository)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _headersToken = headersToken;
               _keycloakRepository = keycloakRepository;
          }

          public async Task<ChangePasswordResponseDTO> Execute(ChangePasswordRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();
               bool temporaryPassword = false;

               try
               {

                    //   Headers Token
                    var token = _headersToken.GetToken();
                    _headersToken.SetAuthorizationHeader(client);

                    // Introspect Token
                    var (userId, role, email) = await _keycloakRepository.IntrospectTokenAsync(client, token);

                    // Validar si el email coincide
                    if (!string.Equals(email, request.UserEmail, StringComparison.OrdinalIgnoreCase))
                    {
                         return new ChangePasswordResponseDTO { Success = false, Message = "Email does not match.", Time = DateTime.UtcNow, UserEmail = request.UserEmail };
                    }

                    // Change Password
                    var passwordChanged = await _keycloakRepository.ChangeUserPasswordAsync(client, userId, request.NewPassword, temporaryPassword);
                    if (!passwordChanged)
                    {
                         throw new Exception("Error changing password.");
                    }

                    return new ChangePasswordResponseDTO
                    {
                         Success = true,
                         Message = "Password changed successfully",
                         TemporaryPassword = temporaryPassword,
                         Time = DateTime.UtcNow,
                         UserEmail = request.UserEmail
                    };
               }
               catch (UnauthorizedAccessException ex)
               {
                    return new ChangePasswordResponseDTO
                    {
                         Success = false,
                         Message = $"Unauthorized access: {ex.Message}",
                         Time = DateTime.UtcNow,
                         UserEmail = request.UserEmail
                    };
               }
               catch (Exception ex)
               {
                    return new ChangePasswordResponseDTO
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