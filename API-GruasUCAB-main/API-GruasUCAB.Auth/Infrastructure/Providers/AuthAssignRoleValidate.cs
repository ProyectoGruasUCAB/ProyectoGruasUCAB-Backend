using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.KeycloakRepository;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Http;

namespace API_GruasUCAB.Auth.Infrastructure.Providers
{
     public class AssignRoleValidator : IService<AssignRoleRequestDTO, AssignRoleResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly HeadersToken _headersToken;
          private readonly IKeycloakRepository _keycloakRepository;

          public AssignRoleValidator(IHttpClientFactory httpClientFactory, IConfiguration configuration, HeadersToken headersToken, IKeycloakRepository keycloakRepository)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _headersToken = headersToken;
               _keycloakRepository = keycloakRepository;
          }

          public async Task<AssignRoleResponseDTO> Execute(AssignRoleRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();
               var token = _headersToken.GetToken();
               _headersToken.SetAuthorizationHeader(client);

               // Obtener el ID del cliente utilizando el nombre del cliente
               var clientId = await _keycloakRepository.GetClientIdAsync(client);
               if (string.IsNullOrEmpty(clientId))
               {
                    return new AssignRoleResponseDTO { Success = false, Message = "No se pudo encontrar el ID del cliente." };
               }

               // Obtener el rol utilizando el nombre del rol
               var role = await _keycloakRepository.GetRoleAsync(client, clientId, request.RoleName);
               if (role == null || !role.Value.TryGetProperty("id", out var roleIdElement))
               {
                    return new AssignRoleResponseDTO { Success = false, Message = "No se pudo encontrar el rol del cliente." };
               }

               var roleId = roleIdElement.GetString();
               if (string.IsNullOrEmpty(roleId))
               {
                    return new AssignRoleResponseDTO { Success = false, Message = "El ID del rol es nulo o vacío." };
               }

               // Asignar el rol al usuario
               var roleAssigned = await _keycloakRepository.AssignRoleAsync(client, request.UserId, clientId, roleId, request.RoleName);
               if (!roleAssigned)
               {
                    return new AssignRoleResponseDTO { Success = false, Message = "No se pudo asignar el rol al usuario." };
               }

               // Verificar que el rol se haya asignado correctamente
               var roleVerified = await _keycloakRepository.VerifyRoleAssignmentAsync(client, request.UserId, clientId, roleId);
               if (!roleVerified)
               {
                    return new AssignRoleResponseDTO { Success = false, Message = "El rol no se asignó correctamente." };
               }

               return new AssignRoleResponseDTO { Success = true, Message = "Role assigned successfully" };
          }
     }
}