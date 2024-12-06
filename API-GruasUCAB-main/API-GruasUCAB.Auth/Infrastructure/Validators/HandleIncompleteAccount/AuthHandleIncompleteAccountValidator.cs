using API_GruasUCAB.Auth.Application.Command.HandleIncompleteAccount;
using API_GruasUCAB.Auth.Application.Command.Logout;
using API_GruasUCAB.Auth.Application.Command.Login;
using API_GruasUCAB.Auth.Infrastructure.DTOs.HandleIncompleteAccount;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Logout;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Login;
using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository;
using API_GruasUCAB.Auth.Infrastructure.Adapters.ClientCredentials;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using MediatR;

namespace API_GruasUCAB.Auth.Infrastructure.Validators.HandleIncompleteAccount
{
     public class AuthHandleIncompleteAccountValidator : IService<IncompleteAccountRequestDTO, IncompleteAccountResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly IMediator _mediator;
          private readonly HeadersToken _headersToken;
          private readonly IHeadersClientCredentialsToken _headersClientCredentialsToken;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IService<LoginRequestDTO, LoginResponseDTO> _loginService;
          private readonly IService<LogoutRequestDTO, LogoutResponseDTO> _logoutService;

          public AuthHandleIncompleteAccountValidator(IHttpClientFactory httpClientFactory, IConfiguration configuration, IMediator mediator, HeadersToken headersToken, IHeadersClientCredentialsToken headersClientCredentialsToken, IKeycloakRepository keycloakRepository, IService<LoginRequestDTO, LoginResponseDTO> loginService, IService<LogoutRequestDTO, LogoutResponseDTO> logoutService)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _mediator = mediator;
               _headersToken = headersToken;
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
                         Email = request.Email,
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
                    Console.WriteLine($"Login successful. RefreshToken: {loginResponse.Message}");

                    // Login successful => Logout
                    await _logoutService.Execute(new LogoutRequestDTO
                    {
                         RefreshToken = loginResponse.RefreshToken
                    });

                    // Throw exception if login was successful but account is not fully set up
                    throw new UnauthorizedException($"{request.Email} does not have a temporary password", new List<string> { "The account is fully set up" });
               }
               catch (UnauthorizedException ex) when (ex.Message.Contains("Account is not fully set up"))
               {
                    // client_credentials
                    var client = _httpClientFactory.CreateClient();
                    bool temporaryPassword = false;
                    await _headersClientCredentialsToken.SetClientCredentialsToken(client);

                    // Email => UserId ^ "UPDATE_PASSWORD"?
                    var (userId, hasRequiredAction) = await _keycloakRepository.GetUserByEmailAsync(client, request.Email, "UPDATE_PASSWORD");

                    if (!hasRequiredAction)
                    {
                         return new IncompleteAccountResponseDTO { Success = false, Message = "El usuario no tiene una contraseña temporal.", Email = request.Email, Time = DateTime.UtcNow };
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
                         Email = request.Email,
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
                         Email = request.Email,
                         Time = DateTime.UtcNow
                    };
               }
               catch (Exception ex)
               {
                    return new IncompleteAccountResponseDTO
                    {
                         Success = false,
                         Message = ex.Message,
                         Email = request.Email,
                         Time = DateTime.UtcNow
                    };
               }
          }
     }
}