using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository;
using API_GruasUCAB.Auth.Infrastructure.Adapters.ClientCredentials;
using API_GruasUCAB.Auth.Infrastructure.Adapters.Email;
using API_GruasUCAB.Auth.Infrastructure.DTOs.RecoverPassword;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Email;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.PasswordGenerator;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Collections.Generic;

namespace API_GruasUCAB.Auth.Infrastructure.Validators.RecoverPassword
{
     public class AuthRecoverPasswordValidate : IService<RecoverPasswordRequestDTO, RecoverPasswordResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly HeadersToken _headersToken;
          private readonly IHeadersClientCredentialsToken _headersClientCredentialsToken;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly EmailProcessor _emailProcessor;

          public AuthRecoverPasswordValidate(IHttpClientFactory httpClientFactory, IConfiguration configuration, HeadersToken headersToken, IHeadersClientCredentialsToken headersClientCredentialsToken, IKeycloakRepository keycloakRepository, EmailProcessor emailProcessor)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _headersToken = headersToken;
               _headersClientCredentialsToken = headersClientCredentialsToken;
               _keycloakRepository = keycloakRepository;
               _emailProcessor = emailProcessor;
          }

          public async Task<RecoverPasswordResponseDTO> Execute(RecoverPasswordRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();
               bool temporaryPassword = true;
               try
               {
                    //   client_credentials
                    await _headersClientCredentialsToken.SetClientCredentialsToken(client);

                    //   Email => UserId ^ "UPDATE_PASSWORD"?
                    var (userId, hasRequiredAction) = await _keycloakRepository.GetUserByEmailAsync(client, request.Email, "UPDATE_PASSWORD");

                    if (hasRequiredAction)
                    {
                         return new RecoverPasswordResponseDTO
                         {
                              Success = false,
                              Message = "The user already has a temporary password.",
                              Time = DateTime.UtcNow,
                              Email = request.Email
                         };
                    }

                    //   New Password
                    var password = PasswordGenerator.GeneratePassword();
                    Console.WriteLine($"\n\nGenerated password: {password}\n\n");

                    //   Reset Password
                    var passwordReset = await _keycloakRepository.ResetPasswordAsync(client, userId, password, temporaryPassword);
                    if (!passwordReset)
                    {
                         throw new Exception("Error resetting password.");
                    }


                    // Enviar correo electrónico con la contraseña generada
                    var emailResponse = await _emailProcessor.SendEmailAsync(request.Email, "Password Recovery", "temporary-password.ftl", new Dictionary<string, string> { { "password", password } });
                    if (!emailResponse.Success)
                    {
                         return new RecoverPasswordResponseDTO
                         {
                              Success = false,
                              Message = "Error sending recovery email",
                              Time = DateTime.UtcNow,
                              Email = request.Email
                         };
                    }

                    return new RecoverPasswordResponseDTO
                    {
                         Success = true,
                         Message = "Password recovery email sent successfully",
                         Time = DateTime.UtcNow,
                         Email = request.Email,
                         TemporaryPassword = temporaryPassword
                    };
               }
               catch (UnauthorizedException ex)
               {
                    return new RecoverPasswordResponseDTO
                    {
                         Success = false,
                         Message = $"Unauthorized access: {ex.Message}",
                         Time = DateTime.UtcNow,
                         Email = request.Email
                    };
               }
               catch (Exception ex)
               {
                    return new RecoverPasswordResponseDTO
                    {
                         Success = false,
                         Message = ex.Message,
                         Time = DateTime.UtcNow,
                         Email = request.Email
                    };
               }
          }
     }
}