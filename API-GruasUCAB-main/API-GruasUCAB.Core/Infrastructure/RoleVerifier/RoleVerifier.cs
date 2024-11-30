using API_GruasUCAB.Commons.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace API_GruasUCAB.Core.Infrastructure.RoleVerifier
{
     public class RoleVerifier
     {
          private readonly IConfiguration _configuration;

          public RoleVerifier(IConfiguration configuration)
          {
               _configuration = configuration;
          }

          // Verifica si el token del cliente tiene los roles permitidos
          public async Task<bool> VerifyClientRoles(HttpClient client, string token)
          {
               var introspectEndpoint = GetIntrospectUrl();
               var introspectRequestContent = BuildIntrospectRequestContent(token);

               var introspectResponse = await client.PostAsync(introspectEndpoint, new FormUrlEncodedContent(introspectRequestContent));
               var introspectContent = await introspectResponse.Content.ReadAsStringAsync();
               if (!introspectResponse.IsSuccessStatusCode)
               {
                    throw new UnauthorizedAccessException("No se pudo introspectar el token.");
               }

               var introspectResult = JsonDocument.Parse(introspectContent).RootElement;
               var clientId = _configuration["Keycloak:ClientId"];
               var allowedRoles = _configuration.GetSection("AllowedRoles").Get<string[]>();

               if (string.IsNullOrEmpty(clientId) || allowedRoles == null)
               {
                    throw new ConfigurationException("ClientId or AllowedRoles configuration is missing for Keycloak.");
               }

               if (introspectResult.TryGetProperty("resource_access", out var resourceAccess) &&
                   resourceAccess.TryGetProperty(clientId, out var clientAccess) &&
                   clientAccess.TryGetProperty("roles", out var rolesElement))
               {
                    var roles = rolesElement.EnumerateArray();
                    foreach (var role in roles)
                    {
                         if (allowedRoles.Contains(role.GetString()))
                         {
                              return true;
                         }
                    }
               }

               return false;
          }

          // Verifica si el usuario tiene los roles necesarios para crear usuarios
          public async Task<bool> CanCreateUser(HttpClient client, string token)
          {
               var roles = await GetUserRoles(client, token);
               return roles.Contains("Administrador") || roles.Contains("Proveedor");
          }

          // Verifica si el usuario tiene los roles necesarios para asignar roles
          public async Task<bool> CanAssignRole(HttpClient client, string token, string roleToAssign, string userId)
          {
               var roles = await GetUserRoles(client, token);
               if (roles.Contains("Administrador"))
               {
                    return true;
               }

               if (roles.Contains("Proveedor"))
               {
                    var userRoles = await GetUserRolesById(client, userId);
                    return roleToAssign == "Conductor" && !userRoles.Contains("ClienteID");
               }

               return false;
          }

          // Verifica si el usuario tiene los roles necesarios para eliminar usuarios
          public async Task<bool> CanDeleteUser(HttpClient client, string token, string userId)
          {
               var roles = await GetUserRoles(client, token);
               if (roles.Contains("Administrador"))
               {
                    return true;
               }

               if (roles.Contains("Proveedor"))
               {
                    var userRoles = await GetUserRolesById(client, userId);
                    return !userRoles.Contains("ClienteID") || userRoles.Contains("Conductor");
               }

               return false;
          }

          // Obtiene los roles del usuario a partir del token
          private async Task<List<string>> GetUserRoles(HttpClient client, string token)
          {
               var introspectEndpoint = GetIntrospectUrl();
               var introspectRequestContent = BuildIntrospectRequestContent(token);

               var introspectResponse = await client.PostAsync(introspectEndpoint, new FormUrlEncodedContent(introspectRequestContent));
               var introspectContent = await introspectResponse.Content.ReadAsStringAsync();
               if (!introspectResponse.IsSuccessStatusCode)
               {
                    throw new UnauthorizedAccessException("No se pudo introspectar el token.");
               }

               var introspectResult = JsonDocument.Parse(introspectContent).RootElement;
               var clientId = _configuration["Keycloak:ClientId"];

               if (string.IsNullOrEmpty(clientId))
               {
                    throw new ConfigurationException("ClientId configuration is missing or invalid.");
               }

               if (introspectResult.TryGetProperty("resource_access", out var resourceAccess) &&
                   resourceAccess.TryGetProperty(clientId, out var clientAccess) &&
                   clientAccess.TryGetProperty("roles", out var rolesElement))
               {
                    return rolesElement.EnumerateArray()
                        .Select(role => role.GetString())
                        .Where(role => role != null)
                        .Cast<string>()
                        .ToList();
               }

               return new List<string>();
          }

          // Obtiene los roles de un usuario específico por su ID
          private async Task<List<string>> GetUserRolesById(HttpClient client, string userId)
          {
               var userByIdUrl = GetUserByIdEndpoint(_configuration, userId);
               var userResponse = await client.GetAsync(userByIdUrl);
               var userContent = await userResponse.Content.ReadAsStringAsync();

               if (!userResponse.IsSuccessStatusCode)
               {
                    throw new Exception($"Error al obtener los roles del usuario: {userContent}");
               }

               var userJson = JsonDocument.Parse(userContent);
               if (userJson.RootElement.TryGetProperty("roles", out var rolesElement))
               {
                    return rolesElement.EnumerateArray()
                        .Select(role => role.GetString())
                        .Where(role => role != null)
                        .Cast<string>()
                        .ToList();
               }

               return new List<string>();
          }

          // Devuelve la URL de introspección del token
          private string GetIntrospectUrl()
          {
               var protocol = _configuration["Keycloak:ProtocolhttpPath"];
               var host = _configuration["Keycloak:Host"];
               var port = _configuration["Keycloak:Port"];
               var realmPath = _configuration["Keycloak:RealmPath"];
               var realm = _configuration["Keycloak:Realm"];
               var openidConnectPath = _configuration["Keycloak:OpenidConnectPath"];
               var introspectPath = _configuration["Keycloak:IntrospectPath"];

               return $"{protocol}{host}:{port}{realmPath}{realm}{openidConnectPath}{introspectPath}";
          }

          // Construye el contenido de la solicitud de introspección del token
          private IEnumerable<KeyValuePair<string, string>> BuildIntrospectRequestContent(string token)
          {
               var clientId = _configuration["Keycloak:ClientId"];
               var clientSecret = _configuration["Keycloak:ClientSecret"];

               // Verificar que los valores no sean nulos o vacíos
               if (string.IsNullOrEmpty(clientId))
               {
                    throw new ConfigurationException("ClientId configuration is missing or invalid.");
               }

               if (string.IsNullOrEmpty(clientSecret))
               {
                    throw new ConfigurationException("ClientSecret configuration is missing or invalid.");
               }

               var request = new Dictionary<string, string>
            {
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "token", token }
            };

               return request;
          }

          // Devuelve la URL del usuario por ID
          private static string GetUserByIdEndpoint(IConfiguration configuration, string userId)
          {
               var userEndpoint = GetUserEndpoint(configuration);
               if (string.IsNullOrEmpty(userId))
               {
                    throw new ConfigurationException("UserId cannot be null or empty.");
               }
               return $"{userEndpoint}/{userId}";
          }

          // Devuelve la URL base del usuario
          private static string GetUserEndpoint(IConfiguration configuration)
          {
               var protocol = configuration["Keycloak:ProtocolhttpPath"];
               var host = configuration["Keycloak:Host"];
               var port = configuration["Keycloak:Port"];
               var adminPath = configuration["Keycloak:AdminPath"];
               var realmPath = configuration["Keycloak:RealmPath"];
               var realm = configuration["Keycloak:Realm"];
               var userPath = configuration["Keycloak:UserPath"];

               return $"{protocol}{host}:{port}{adminPath}{realmPath}{realm}{userPath}";
          }
     }
}