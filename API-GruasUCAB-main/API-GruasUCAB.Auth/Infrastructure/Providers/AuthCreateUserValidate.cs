using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;
using API_GruasUCAB.Core.Infrastructure.PasswordGenerator;
using API_GruasUCAB.Core.Infrastructure.KeycloakRepository;
using API_GruasUCAB.Core.Infrastructure.ClientCredentials;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.IO;
using System.Text.Json;

namespace API_GruasUCAB.Auth.Infrastructure.Providers
{
     public class AuthCreateUserValidate : IService<CreateUserRequestDTO, CreateUserResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly HeadersToken _headersToken;
          private readonly IHeadersClientCredentialsToken _headersClientCredentialsToken;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IService<EmailRequestDTO, EmailResponseDTO> _emailService;
          private readonly IService<DeleteUserRequestDTO, DeleteUserResponseDTO> _deleteUserService;

          public AuthCreateUserValidate(IHttpClientFactory httpClientFactory, IConfiguration configuration, HeadersToken headersToken, IHeadersClientCredentialsToken headersClientCredentialsToken, IKeycloakRepository keycloakRepository, IService<EmailRequestDTO, EmailResponseDTO> emailService, IService<DeleteUserRequestDTO, DeleteUserResponseDTO> deleteUserService)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _headersToken = headersToken;
               _headersClientCredentialsToken = headersClientCredentialsToken;
               _keycloakRepository = keycloakRepository;
               _emailService = emailService;
               _deleteUserService = deleteUserService;
          }

          public async Task<CreateUserResponseDTO> Execute(CreateUserRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();
               var userEndpoint = _keycloakRepository.GetUserEndpoint(_configuration);

               // Obtener el token del encabezado Authorization
               var token = _headersToken.GetToken();
               _headersToken.SetAuthorizationHeader(client);

               // Generar una contraseña aleatoria de 6 dígitos
               var password = PasswordGenerator.GeneratePassword();
               Console.WriteLine($"\n\nGenerated password: {password}\n\n");

               var userRequestContent = _keycloakRepository.BuildUserCreationJson(request.Email, password);

               var response = await client.PostAsync(userEndpoint, userRequestContent);
               var content = await response.Content.ReadAsStringAsync();

               if (!response.IsSuccessStatusCode)
               {
                    return new CreateUserResponseDTO { Success = false, Message = content };
               }

               // Obtener el ID del nuevo usuario utilizando el email
               var userId = await _keycloakRepository.GetUserIdByEmailAsync(client, request.Email);
               if (string.IsNullOrEmpty(userId))
               {
                    return new CreateUserResponseDTO { Success = false, Message = "UserID is null or empty" };
               }

               // Leer la plantilla de correo electrónico
               var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "new-user.ftl");
               var emailBody = await File.ReadAllTextAsync(templatePath);

               // Reemplazar los marcadores de posición con los valores reales
               emailBody = emailBody.Replace("{{password}}", password);

               // Crear la solicitud de correo electrónico
               var emailRequest = new EmailRequestDTO
               {
                    ToEmail = request.Email,
                    Subject = "Cuenta creada",
                    Body = emailBody
               };

               // Enviar correo electrónico con la contraseña generada
               var emailResponse = await _emailService.Execute(emailRequest);
               if (!emailResponse.Success)
               {
                    var deleteUserResponse = await _deleteUserService.Execute(new DeleteUserRequestDTO { Email = request.Email });
                    if (!deleteUserResponse.Success)
                    {
                         return new CreateUserResponseDTO { Success = false, Message = "Error al enviar el correo electrónico y al eliminar el usuario" };
                    }
                    throw new Exception("Error al enviar el correo electrónico");
               }

               return new CreateUserResponseDTO { Success = true, Message = userId };
          }
     }
}