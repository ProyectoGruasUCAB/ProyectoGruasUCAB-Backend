namespace API_GruasUCAB.Auth.Infrastructure.Validators.Login
{
    public class AuthLoginValidate : IService<LoginRequestDTO, LoginResponseDTO>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IKeycloakRepository _keycloakRepository;
        private readonly INewWorkerRepository _newWorkerRepository;
        private readonly INewProviderRepository _newProviderRepository;
        private readonly INewDriverRepository _newDriverRepository;

        public AuthLoginValidate(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IKeycloakRepository keycloakRepository,
            INewWorkerRepository newWorkerRepository,
            INewProviderRepository newProviderRepository,
            INewDriverRepository newDriverRepository)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _keycloakRepository = keycloakRepository;
            _newWorkerRepository = newWorkerRepository;
            _newProviderRepository = newProviderRepository;
            _newDriverRepository = newDriverRepository;
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
                var (userIdString, role, _) = await _keycloakRepository.IntrospectTokenAsync(client, accessToken);

                if (!Guid.TryParse(userIdString, out Guid userId))
                {
                    throw new ArgumentException("Invalid User ID format");
                }

                Guid? workerId = Guid.Empty;
                string position = string.Empty;
                if (role == "Trabajador")
                {
                    var workerInfo = await _newWorkerRepository.GetDepartmentAndPositionByUserId(userId);
                    if (workerInfo.HasValue)
                    {
                        workerId = workerInfo.Value.DepartmentId;
                        position = workerInfo.Value.Position;
                    }
                }
                else if (role == "Proveedor")
                {
                    workerId = await _newProviderRepository.GetSupplierIdByUserId(userId);
                }
                else if (role == "Conductor")
                {
                    workerId = await _newDriverRepository.GetSupplierIdByUserId(userId);
                }

                return new LoginResponseDTO
                {
                    Success = true,
                    Message = "Login successful",
                    Time = DateTime.UtcNow,
                    UserEmail = request.UserEmail,
                    Token = accessToken,
                    RefreshToken = refreshToken,
                    UserID = userIdString,
                    Role = role,
                    WorkerId = workerId,
                    WorkerName = position ?? string.Empty
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