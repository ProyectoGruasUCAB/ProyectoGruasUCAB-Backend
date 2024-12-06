using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository;
using API_GruasUCAB.Auth.Infrastructure.DTOs.AssignRole;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System;

namespace API_GruasUCAB.Auth.Infrastructure.Validators.AssignRole
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
               //   Headers Token
               _headersToken.SetAuthorizationHeader(client);

               try
               {
                    //   Search ID Client
                    var clientId = await _keycloakRepository.GetClientIdAsync(client);
                    if (string.IsNullOrEmpty(clientId))
                    {
                         return new AssignRoleResponseDTO { Success = false, Message = "No se pudo encontrar el ID del cliente.", Time = DateTime.UtcNow };
                    }

                    //   RoleName => RoleID
                    var roleId = await _keycloakRepository.GetRoleAsync(client, clientId, request.RoleName);
                    if (string.IsNullOrEmpty(roleId))
                    {
                         return new AssignRoleResponseDTO { Success = false, Message = "No se pudo encontrar el rol del cliente.", Time = DateTime.UtcNow };
                    }

                    //   Assign Role
                    if (!await _keycloakRepository.AssignRoleAsync(client, request.UserId, clientId, roleId, request.RoleName))
                    {
                         return new AssignRoleResponseDTO { Success = false, Message = "No se pudo asignar el rol al usuario.", Time = DateTime.UtcNow };
                    }

                    //   Verify Role Assignment
                    if (!await _keycloakRepository.VerifyRoleAssignmentAsync(client, request.UserId, clientId, roleId))
                    {
                         return new AssignRoleResponseDTO { Success = false, Message = "El rol no se asignó correctamente.", Time = DateTime.UtcNow };
                    }

                    return new AssignRoleResponseDTO
                    {
                         Success = true,
                         Message = "Role assigned successfully",
                         UserId = request.UserId,
                         RoleName = request.RoleName,
                         Time = DateTime.UtcNow
                    };
               }
               catch (UnauthorizedAccessException ex)
               {
                    return new AssignRoleResponseDTO { Success = false, Message = $"Unauthorized access: {ex.Message}", Time = DateTime.UtcNow };
               }
               catch (Exception ex)
               {
                    return new AssignRoleResponseDTO { Success = false, Message = ex.Message, Time = DateTime.UtcNow };
               }
          }
     }
}