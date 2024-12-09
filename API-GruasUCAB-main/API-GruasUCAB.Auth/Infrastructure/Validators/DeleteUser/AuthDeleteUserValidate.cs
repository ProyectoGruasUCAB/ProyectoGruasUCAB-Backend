namespace API_GruasUCAB.Auth.Infrastructure.Validators.DeleteUser
{
     public class AuthDeleteUserValidate : IService<DeleteUserRequestDTO, DeleteUserResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IHeadersClientCredentialsToken _headersClientCredentialsToken;
          private readonly HeadersToken _headersToken;

          public AuthDeleteUserValidate(IHttpClientFactory httpClientFactory, IConfiguration configuration, IKeycloakRepository keycloakRepository, IHeadersClientCredentialsToken headersClientCredentialsToken, HeadersToken headersToken)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _keycloakRepository = keycloakRepository;
               _headersClientCredentialsToken = headersClientCredentialsToken;
               _headersToken = headersToken;
          }

          public async Task<DeleteUserResponseDTO> Execute(DeleteUserRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();

               try
               {
                    // Headers Token
                    var token = _headersToken.GetToken();
                    _headersToken.SetAuthorizationHeader(client);

                    // Introspect Token
                    var (_, role, email) = await _keycloakRepository.IntrospectTokenAsync(client, token);

                    // Validar si el email coincide
                    if (!string.Equals(email, request.UserEmail, StringComparison.OrdinalIgnoreCase))
                    {
                         return new DeleteUserResponseDTO { Success = false, Message = "Email does not match.", DeletedUserEmail = request.EmailToDelete, Time = DateTime.UtcNow, UserEmail = request.UserEmail };
                    }

                    // client_credentials 
                    //await _headersClientCredentialsToken.SetClientCredentialsToken(client);

                    // Email => UserID
                    var (userId, _) = await _keycloakRepository.GetUserByEmailAsync(client, request.EmailToDelete, string.Empty);

                    // Delete User
                    var userDeleted = await _keycloakRepository.DeleteUserAsync(client, _configuration, userId);
                    if (!userDeleted)
                    {
                         throw new Exception("Error al eliminar el usuario.");
                    }

                    return new DeleteUserResponseDTO
                    {
                         Success = true,
                         Message = "User deleted successfully",
                         DeletedUserEmail = request.EmailToDelete,
                         Time = DateTime.UtcNow,
                         UserEmail = request.UserEmail
                    };
               }
               catch (UnauthorizedAccessException ex)
               {
                    return new DeleteUserResponseDTO
                    {
                         Success = false,
                         Message = $"Unauthorized access: {ex.Message}",
                         DeletedUserEmail = request.EmailToDelete,
                         Time = DateTime.UtcNow,
                         UserEmail = request.UserEmail
                    };
               }
               catch (Exception ex)
               {
                    return new DeleteUserResponseDTO
                    {
                         Success = false,
                         Message = ex.Message,
                         DeletedUserEmail = request.EmailToDelete,
                         Time = DateTime.UtcNow,
                         UserEmail = request.UserEmail
                    };
               }
          }
     }
}