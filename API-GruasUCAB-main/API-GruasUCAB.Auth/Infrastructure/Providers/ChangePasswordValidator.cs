using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;
using API_GruasUCAB.Core.Infrastructure.KeycloakRepository;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Http;

namespace API_GruasUCAB.Auth.Infrastructure.Providers
{
     public class ChangePasswordValidator : IService<ChangePasswordRequestDTO, ChangePasswordResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly HeadersToken _headersToken;
          private readonly IKeycloakRepository _keycloakRepository;

          public ChangePasswordValidator(IHttpClientFactory httpClientFactory, IConfiguration configuration, HeadersToken headersToken, IKeycloakRepository keycloakRepository)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _headersToken = headersToken;
               _keycloakRepository = keycloakRepository;
          }

          public async Task<ChangePasswordResponseDTO> Execute(ChangePasswordRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();
               var token = _headersToken.GetToken();
               _headersToken.SetAuthorizationHeader(client);

               var introspectionRequest = new TokenIntrospectionRequestDTO
               {
                    Token = token,
                    ExpectedTokenType = "client_id"
               };

               var userId = await _keycloakRepository.IntrospectTokenAsync(client, introspectionRequest);
               if (string.IsNullOrEmpty(userId))
               {
                    return new ChangePasswordResponseDTO { Success = false, Message = "No se pudo introspectar el token o el token es de tipo client_credentials." };
               }

               var userEndpoint = _keycloakRepository.GetResetPasswordEndpoint(_configuration, userId);
               var passwordContent = _keycloakRepository.BuildPasswordChangeJson(request.NewPassword, false);

               var passwordResponse = await client.PutAsync(userEndpoint, passwordContent);
               var passwordResponseContent = await passwordResponse.Content.ReadAsStringAsync();
               if (!passwordResponse.IsSuccessStatusCode)
               {
                    return new ChangePasswordResponseDTO { Success = false, Message = $"No se pudo cambiar la contraseña. Detalles: {passwordResponseContent}" };
               }
               return new ChangePasswordResponseDTO { Success = true, Message = "Contraseña cambiada exitosamente." };
          }
     }
}