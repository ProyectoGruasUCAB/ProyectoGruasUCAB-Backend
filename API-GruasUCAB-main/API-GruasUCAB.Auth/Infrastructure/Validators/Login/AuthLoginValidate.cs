namespace API_GruasUCAB.Auth.Infrastructure.Validators.Login
{
    public class AuthLoginValidate : IService<LoginRequestDTO, LoginResponseDTO>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IKeycloakRepository _keycloakRepository;

        public AuthLoginValidate(IHttpClientFactory httpClientFactory, IConfiguration configuration, IKeycloakRepository keycloakRepository)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _keycloakRepository = keycloakRepository;
        }

        public async Task<LoginResponseDTO> Execute(LoginRequestDTO request)
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                // Login
                var (accessToken, refreshToken) = await _keycloakRepository.GetTokenAsync(client, request.UserEmail, request.Password);
                var authType = _configuration["Keycloak:Auth_Type"];
                if (string.IsNullOrEmpty(authType))
                {
                    throw new ConfigurationException("Auth_Type configuration is missing for JwtBearer.");
                }
                //  Headers AccessToken
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(authType, accessToken);

                // Introspect Token => UserID ^ Role
                var (userId, role, _) = await _keycloakRepository.IntrospectTokenAsync(client, accessToken);

                return new LoginResponseDTO
                {
                    Success = true,
                    Message = "Login successful",
                    Time = DateTime.UtcNow,
                    UserEmail = request.UserEmail,
                    Token = accessToken,
                    RefreshToken = refreshToken,
                    UserID = userId,
                    Role = role
                };
            }
            catch (UnauthorizedException ex)
            {
                return new LoginResponseDTO
                {
                    Success = false,
                    Message = $"Unauthorized access: {ex.Message}",
                    UserEmail = request.UserEmail,
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new LoginResponseDTO
                {
                    Success = false,
                    Message = ex.Message,
                    UserEmail = request.UserEmail,
                    Time = DateTime.UtcNow
                };
            }
        }
    }
}