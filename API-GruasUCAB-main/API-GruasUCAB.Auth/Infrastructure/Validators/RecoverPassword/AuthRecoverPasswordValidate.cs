using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository;
using API_GruasUCAB.Auth.Infrastructure.Adapters.ClientCredentials;
using API_GruasUCAB.Auth.Infrastructure.Adapters.HeadersToken;
using API_GruasUCAB.Auth.Infrastructure.Adapters.Email;
using API_GruasUCAB.Auth.Infrastructure.DTOs.RecoverPassword;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Email;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.PasswordGenerator;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System;

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
                    var (userId, hasRequiredAction) = await _keycloakRepository.GetUserByEmailAsync(client, request.UserEmail, "UPDATE_PASSWORD");

                    if (hasRequiredAction)
                    {
                         return new RecoverPasswordResponseDTO
                         {
                              Success = false,
                              Message = "The user already has a temporary password.",
                              UserEmail = request.UserEmail,
                              Time = DateTime.UtcNow
                         };
                    }

                    //   New Password
                    var password = PasswordGenerator.GeneratePassword();

                    //   Reset Password
                    var passwordReset = await _keycloakRepository.ResetPasswordAsync(client, userId, password, temporaryPassword);
                    if (!passwordReset)
                    {
                         throw new Exception("Error resetting password.");
                    }


                    // Enviar correo electrónico con la contraseña generada
                    var emailResponse = await _emailProcessor.SendEmailAsync(request.UserEmail, "Password Recovery", "temporary-password.ftl", new Dictionary<string, string> { { "password", password } });
                    if (!emailResponse.Success)
                    {
                         return new RecoverPasswordResponseDTO
                         {
                              Success = false,
                              Message = "Error sending recovery email",
                              UserEmail = request.UserEmail,
                              Time = DateTime.UtcNow
                         };
                    }

                    Console.WriteLine($"\n\nGenerated password: {password}\n\n");
                    return new RecoverPasswordResponseDTO
                    {
                         Success = true,
                         Message = "Password recovery email sent successfully",
                         UserEmail = request.UserEmail,
                         Time = DateTime.UtcNow,
                         TemporaryPassword = temporaryPassword
                    };
               }
               catch (UnauthorizedException ex)
               {
                    return new RecoverPasswordResponseDTO
                    {
                         Success = false,
                         Message = $"Unauthorized access: {ex.Message}",
                         UserEmail = request.UserEmail,
                         Time = DateTime.UtcNow
                    };
               }
               catch (Exception ex)
               {
                    return new RecoverPasswordResponseDTO
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