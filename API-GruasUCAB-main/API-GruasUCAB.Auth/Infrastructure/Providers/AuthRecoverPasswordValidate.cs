using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;
using API_GruasUCAB.Core.Infrastructure.ClientCredentials;
using API_GruasUCAB.Core.Infrastructure.KeycloakRepository;
using API_GruasUCAB.Core.Infrastructure.PasswordGenerator;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.IO;
using System.Text.Json;

namespace API_GruasUCAB.Auth.Infrastructure.Providers
{
     public class AuthRecoverPasswordValidate : IService<RecoverPasswordRequestDTO, RecoverPasswordResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly IHeadersClientCredentialsToken _headersClientCredentialsToken;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IService<EmailRequestDTO, EmailResponseDTO> _emailService;

          public AuthRecoverPasswordValidate(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHeadersClientCredentialsToken headersClientCredentialsToken, IKeycloakRepository keycloakRepository, IService<EmailRequestDTO, EmailResponseDTO> emailService)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _headersClientCredentialsToken = headersClientCredentialsToken;
               _keycloakRepository = keycloakRepository;
               _emailService = emailService;
          }

          public async Task<RecoverPasswordResponseDTO> Execute(RecoverPasswordRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();

               // 1. Obtener y configurar el token client_credentials
               await _headersClientCredentialsToken.SetClientCredentialsToken(client);

               // 2. Obtener el UserID utilizando el clientAccessToken
               var userByEmailUrl = _keycloakRepository.GetUserByEmailUrl(_configuration, request.Email);
               var userResponse = await client.GetAsync(userByEmailUrl);
               var userContent = await userResponse.Content.ReadAsStringAsync();

               if (!userResponse.IsSuccessStatusCode)
               {
                    return new RecoverPasswordResponseDTO { Success = false, Message = $"Error al obtener el UserID: {userContent}" };
               }

               var userJson = JsonDocument.Parse(userContent);
               var userId = userJson.RootElement[0].GetProperty("id").GetString();

               if (string.IsNullOrEmpty(userId))
               {
                    return new RecoverPasswordResponseDTO { Success = false, Message = "UserID is null or empty" };
               }

               // 3. Verificar si el usuario No tiene la acción requerida "UPDATE_PASSWORD"
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

               if (hasUpdatePasswordAction)
               {
                    return new RecoverPasswordResponseDTO { Success = false, Message = "El usuario ya tiene una contraseña temporal." };
               }

               // 4. Obtener el endpoint para resetear la contraseña
               var resetPasswordEndpoint = _keycloakRepository.GetResetPasswordEndpoint(_configuration, userId);

               // 5. Generar una contraseña aleatoria de 6 dígitos
               var password = PasswordGenerator.GeneratePassword();
               Console.WriteLine($"\n\nGenerated password: {password}\n\n");

               // 6. Construir la solicitud para resetear la contraseña
               var resetPasswordRequest = _keycloakRepository.BuildPasswordChangeJson(password, true);

               var resetPasswordResponse = await client.PutAsync(resetPasswordEndpoint, resetPasswordRequest);
               var resetPasswordContent = await resetPasswordResponse.Content.ReadAsStringAsync();

               if (!resetPasswordResponse.IsSuccessStatusCode)
               {
                    return new RecoverPasswordResponseDTO { Success = false, Message = $"Error al resetear la contraseña: {resetPasswordContent}" };
               }

               // 7. Leer la plantilla de correo electrónico
               var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "temporary-password.ftl");
               var emailBody = await File.ReadAllTextAsync(templatePath);

               // Reemplazar los marcadores de posición con los valores reales
               emailBody = emailBody.Replace("{{password}}", password);

               // Enviar correo electrónico con la contraseña generada
               var emailRequest = new EmailRequestDTO
               {
                    ToEmail = request.Email,
                    Subject = "Password Recovery",
                    Body = emailBody
               };

               var emailResponse = await _emailService.Execute(emailRequest);
               if (!emailResponse.Success)
               {
                    return new RecoverPasswordResponseDTO { Success = false, Message = "Error sending recovery email" };
               }

               return new RecoverPasswordResponseDTO { Success = true, Message = "Password reset successfully" };
          }
     }
}