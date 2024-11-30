using API_GruasUCAB.Auth.Application.Command.Login;
using API_GruasUCAB.Auth.Application.Command.Logout;
using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.KeycloakRequestBuilder;
using API_GruasUCAB.Core.Infrastructure.UrlHelperKeycloak;
using API_GruasUCAB.Core.Infrastructure.ClientCredentials;
using API_GruasUCAB.Core.Infrastructure.KeycloakRepository;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using System;
using MediatR;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;

namespace API_GruasUCAB.Auth.Infrastructure.Providers
{
     public class AuthHandleIncompleteAccountValidator : IService<IncompleteAccountRequestDTO, IncompleteAccountResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly IMediator _mediator;
          private readonly IKeycloakRequestBuilder _keycloakRequestBuilder;
          private readonly IUrlHelperKeycloak _urlHelperKeycloak;
          private readonly HeadersToken _headersToken;
          private readonly IHeadersClientCredentialsToken _headersClientCredentialsToken;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IService<LoginRequestDTO, LoginResponseDTO> _loginService;
          private readonly IService<LogoutRequestDTO, LogoutResponseDTO> _logoutService;

          public AuthHandleIncompleteAccountValidator(IHttpClientFactory httpClientFactory, IConfiguration configuration, IMediator mediator, IKeycloakRequestBuilder keycloakRequestBuilder, IUrlHelperKeycloak urlHelperKeycloak, HeadersToken headersToken, IHeadersClientCredentialsToken headersClientCredentialsToken, IKeycloakRepository keycloakRepository, IService<LoginRequestDTO, LoginResponseDTO> loginService, IService<LogoutRequestDTO, LogoutResponseDTO> logoutService)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _mediator = mediator;
               _keycloakRequestBuilder = keycloakRequestBuilder;
               _urlHelperKeycloak = urlHelperKeycloak;
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
                    // Intentar login
                    var loginResponse = await _loginService.Execute(new LoginRequestDTO
                    {
                         Email = request.Email,
                         Password = request.Password
                    });

                    // Si el login es exitoso, realizar logout para mayor seguridad
                    await _logoutService.Execute(new LogoutRequestDTO
                    {
                         RefreshToken = loginResponse.RefreshToken
                    });

                    // Lanzar excepción de cuenta no completamente configurada
                    throw new UnauthorizedException("Invalid credentials", new List<string> { "Account is not fully set up" });
               }
               catch (UnauthorizedException ex) when (ex.Message.Contains("Invalid credentials") && ex.Errors.Contains("Account is not fully set up"))
               {
                    // Continuar con el flujo de client_credentials si la cuenta no está completamente configurada

                    var client = _httpClientFactory.CreateClient();

                    // Obtener y configurar el token client_credentials
                    await _headersClientCredentialsToken.SetClientCredentialsToken(client);

                    // Obtener el UserID utilizando el clientAccessToken
                    var userByEmailUrl = _urlHelperKeycloak.GetUserByEmailUrl(_configuration, request.Email);
                    var userResponse = await client.GetAsync(userByEmailUrl);
                    var userContent = await userResponse.Content.ReadAsStringAsync();

                    if (!userResponse.IsSuccessStatusCode)
                    {
                         throw new Exception($"Error al obtener el UserID: {userContent}");
                    }

                    var userJson = JsonDocument.Parse(userContent);
                    var userId = userJson.RootElement[0].GetProperty("id").GetString();

                    if (string.IsNullOrEmpty(userId))
                    {
                         throw new Exception("UserID is null or empty");
                    }

                    // Verificar si el usuario tiene la acción requerida "UPDATE_PASSWORD"
                    var requiredActions = userJson.RootElement[0].GetProperty("requiredActions").EnumerateArray();
                    bool hasUpdatePasswordAction = false;
                    foreach (var action in requiredActions)
                    {
                         var actionString = action.GetString();
                         if (!string.IsNullOrEmpty(actionString) && actionString == "UPDATE_PASSWORD")
                         {
                              hasUpdatePasswordAction = true;
                              break;
                         }
                    }

                    if (!hasUpdatePasswordAction)
                    {
                         throw new Exception("El usuario no tiene una contraseña temporal.");
                    }

                    // Obtener el endpoint para resetear la contraseña
                    var resetPasswordEndpoint = _urlHelperKeycloak.GetResetPasswordEndpoint(_configuration, userId);

                    // Construir la solicitud para resetear la contraseña
                    var resetPasswordRequest = _keycloakRequestBuilder
                        .WithNewPassword(request.NewPassword, false)
                        .BuildPasswordChangeJson();

                    var resetPasswordResponse = await client.PutAsync(resetPasswordEndpoint, resetPasswordRequest);
                    var resetPasswordContent = await resetPasswordResponse.Content.ReadAsStringAsync();

                    if (!resetPasswordResponse.IsSuccessStatusCode)
                    {
                         throw new Exception($"Error al resetear la contraseña: {resetPasswordContent}");
                    }

                    return new IncompleteAccountResponseDTO
                    {
                         Success = true,
                         Message = "Password reset successful"
                    };
               }
               catch (UnauthorizedException ex)
               {
                    // Manejar otras excepciones de autorización
                    return new IncompleteAccountResponseDTO
                    {
                         Success = false,
                         Message = ex.Message
                    };
               }
               catch (Exception ex)
               {
                    // Manejar otras excepciones generales
                    return new IncompleteAccountResponseDTO
                    {
                         Success = false,
                         Message = ex.Message
                    };
               }
          }
     }
}