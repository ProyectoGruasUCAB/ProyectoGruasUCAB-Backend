namespace API_GruasUCAB.Auth.Infrastructure.Validators.HandleIncompleteAccount
{
     public class AuthHandleIncompleteAccountValidator : IService<IncompleteAccountRequestDTO, IncompleteAccountResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IHeadersClientCredentialsToken _headersClientCredentialsToken;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IService<LoginRequestDTO, LoginResponseDTO> _loginService;
          private readonly IService<LogoutRequestDTO, LogoutResponseDTO> _logoutService;

          public AuthHandleIncompleteAccountValidator(IHttpClientFactory httpClientFactory, IHeadersClientCredentialsToken headersClientCredentialsToken, IKeycloakRepository keycloakRepository, IService<LoginRequestDTO, LoginResponseDTO> loginService, IService<LogoutRequestDTO, LogoutResponseDTO> logoutService)
          {
               _httpClientFactory = httpClientFactory;
               _headersClientCredentialsToken = headersClientCredentialsToken;
               _keycloakRepository = keycloakRepository;
               _loginService = loginService;
               _logoutService = logoutService;
          }

          public async Task<IncompleteAccountResponseDTO> Execute(IncompleteAccountRequestDTO request)
          {
               try
               {
                    // Login
                    var loginResponse = await _loginService.Execute(new LoginRequestDTO
                    {
                         UserEmail = request.UserEmail,
                         Password = request.Password
                    });
                    if (loginResponse.Message.Contains("Account is not fully set up"))
                    {
                         throw new UnauthorizedException("Account is not fully set up", new List<string> { "Account is not fully set up" });
                    }
                    if (!loginResponse.Success)
                    {
                         throw new UnauthorizedException("Login failed", new List<string> { loginResponse.Message });
                    }

                    // Login successful => Logout
                    await _logoutService.Execute(new LogoutRequestDTO
                    {
                         UserEmail = request.UserEmail,
                         RefreshToken = loginResponse.RefreshToken
                    });

                    throw new UnauthorizedException($"{request.UserEmail} does not have a temporary password", new List<string> { "The account is fully set up" });
               }
               catch (UnauthorizedException ex) when (ex.Message.Contains("Account is not fully set up"))
               {
                    // client_credentials
                    var client = _httpClientFactory.CreateClient();
                    bool temporaryPassword = false;
                    await _headersClientCredentialsToken.SetClientCredentialsToken(client);

                    // Email => UserId ^ "UPDATE_PASSWORD"?
                    var (userId, hasRequiredAction) = await _keycloakRepository.GetUserByEmailAsync(client, request.UserEmail, "UPDATE_PASSWORD");

                    if (!hasRequiredAction)
                    {
                         return new IncompleteAccountResponseDTO { Success = false, Message = "The user does not have a temporary password.", UserEmail = request.UserEmail, Time = DateTime.UtcNow };
                    }

                    // Reset Password
                    var passwordReset = await _keycloakRepository.ResetPasswordAsync(client, userId, request.NewPassword, temporaryPassword);
                    if (!passwordReset)
                    {
                         throw new Exception("Error resetting password.");
                    }

                    return new IncompleteAccountResponseDTO
                    {
                         Success = true,
                         Message = "Password reset successful",
                         UserEmail = request.UserEmail,
                         TemporaryPassword = temporaryPassword,
                         Time = DateTime.UtcNow
                    };
               }
               catch (UnauthorizedException ex)
               {
                    return new IncompleteAccountResponseDTO
                    {
                         Success = false,
                         Message = ex.Message,
                         UserEmail = request.UserEmail,
                         Time = DateTime.UtcNow
                    };
               }
               catch (Exception ex)
               {
                    return new IncompleteAccountResponseDTO
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