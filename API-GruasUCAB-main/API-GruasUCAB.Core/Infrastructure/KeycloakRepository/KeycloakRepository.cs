using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.KeycloakRequestBuilder;
using API_GruasUCAB.Core.Infrastructure.UrlHelperKeycloak;
using API_GruasUCAB.Core.Infrastructure.KeycloakRepository;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;

namespace API_GruasUCAB.Core.Infrastructure.KeycloakRepository
{
     public class KeycloakRepository : IKeycloakRepository
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly IUrlHelperKeycloak _urlHelperKeycloak;
          private readonly IKeycloakRequestBuilder _keycloakRequestBuilder;

          public KeycloakRepository(IHttpClientFactory httpClientFactory, IConfiguration configuration, IUrlHelperKeycloak urlHelperKeycloak, IKeycloakRequestBuilder keycloakRequestBuilder)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _urlHelperKeycloak = urlHelperKeycloak;
               _keycloakRequestBuilder = keycloakRequestBuilder;
          }

          public async Task<TokenResponse?> GetTokenAsync(HttpClient client, string email, string password)
          {
               var tokenEndpoint = _urlHelperKeycloak.GetTokenUrl(_configuration);

               var tokenRequest = _keycloakRequestBuilder
                   .WithClientId()
                   .WithClientSecret()
                   .WithUsername(email)
                   .WithPassword(password)
                   .WithGrantType("password")
                   .BuildAsForm();

               var formContent = new FormUrlEncodedContent(tokenRequest);
               var response = await client.PostAsync(tokenEndpoint, formContent);
               var content = await response.Content.ReadAsStringAsync();

               if (!response.IsSuccessStatusCode)
               {
                    var errorDetails = JsonDocument.Parse(content).RootElement.GetProperty("error_description").GetString();
                    throw new UnauthorizedException("Invalid credentials", new List<string> { errorDetails ?? "No additional details provided." });
               }

               var jsonDocument = JsonDocument.Parse(content);
               var root = jsonDocument.RootElement;

               return new TokenResponse
               {
                    AccessToken = root.GetProperty("access_token").GetString() ?? string.Empty,
                    RefreshToken = root.GetProperty("refresh_token").GetString() ?? string.Empty
               };
          }

          public async Task<TokenResponse?> GetTokenAsync(HttpClient client, string clientId, string clientSecret, string grantType)
          {
               var tokenEndpoint = _urlHelperKeycloak.GetTokenUrl(_configuration);

               var tokenRequest = _keycloakRequestBuilder
                   .WithClientId()
                   .WithClientSecret()
                   .WithGrantType(grantType)
                   .BuildAsForm();

               var formContent = new FormUrlEncodedContent(tokenRequest);
               var response = await client.PostAsync(tokenEndpoint, formContent);
               var content = await response.Content.ReadAsStringAsync();

               if (!response.IsSuccessStatusCode)
               {
                    return null;
               }

               var jsonDocument = JsonDocument.Parse(content);
               var root = jsonDocument.RootElement;

               return new TokenResponse
               {
                    AccessToken = root.GetProperty("access_token").GetString() ?? string.Empty,
                    RefreshToken = root.GetProperty("refresh_token").GetString() ?? string.Empty
               };
          }

          public async Task<string> GetClientCredentialsTokenAsync(HttpClient client)
          {
               var tokenEndpoint = _urlHelperKeycloak.GetTokenUrl(_configuration);
               var tokenClientCredentialsRequest = _keycloakRequestBuilder
                   .WithClientId()
                   .WithClientSecret()
                   .WithGrantType("client_credentials")
                   .BuildAsForm();

               var formContent = new FormUrlEncodedContent(tokenClientCredentialsRequest);
               var response = await client.PostAsync(tokenEndpoint, formContent);
               var content = await response.Content.ReadAsStringAsync();

               if (!response.IsSuccessStatusCode)
               {
                    throw new Exception($"Error al obtener el access token utilizando client_credentials: {content}");
               }

               var clientCredentialsJson = JsonDocument.Parse(content);
               var clientCredentialsRoot = clientCredentialsJson.RootElement;

               return clientCredentialsRoot.GetProperty("access_token").GetString() ?? string.Empty;
          }

          public async Task<string?> IntrospectTokenAsync(HttpClient client, TokenIntrospectionRequestDTO request)
          {
               var introspectEndpoint = _urlHelperKeycloak.GetIntrospectUrl(_configuration);

               var introspectRequestContent = _keycloakRequestBuilder
                   .WithToken(request.Token)
                   .WithClientId()
                   .WithClientSecret()
                   .BuildAsForm();

               var introspectResponse = await client.PostAsync(introspectEndpoint, new FormUrlEncodedContent(introspectRequestContent));
               var introspectContent = await introspectResponse.Content.ReadAsStringAsync();

               if (!introspectResponse.IsSuccessStatusCode)
               {
                    Console.WriteLine($"Introspection failed: {introspectContent}");
                    return null;
               }

               var introspectResult = JsonDocument.Parse(introspectContent).RootElement;

               // Verificar si el token es del tipo esperado
               if (!string.IsNullOrEmpty(request.ExpectedTokenType) && !introspectResult.TryGetProperty(request.ExpectedTokenType, out _))
               {
                    Console.WriteLine($"Token is of type {request.ExpectedTokenType}");
                    return null;
               }

               return introspectResult.GetProperty("sub").GetString();
          }

          public StringContent BuildUserCreationJson(string email, string password)
          {
               return _keycloakRequestBuilder
                   .WithUsername(email)
                   .WithEmail(email)
                   .WithCredentials(password, true)
                   .WithEnabled(true)
                   .WithEmailVerified(true)
                   .BuildUserCreationJson();
          }

          public async Task<string?> GetUserIdByEmailAsync(HttpClient client, string email)
          {
               var userByEmailUrl = _urlHelperKeycloak.GetUserByEmailUrl(_configuration, email);
               var userResponse = await client.GetAsync(userByEmailUrl);
               var userContent = await userResponse.Content.ReadAsStringAsync();

               if (!userResponse.IsSuccessStatusCode)
               {
                    return null;
               }

               var userJson = JsonDocument.Parse(userContent);
               return userJson.RootElement[0].GetProperty("id").GetString();
          }

          public StringContent BuildPasswordChangeJson(string newPassword, bool temporary)
          {
               return _keycloakRequestBuilder
                   .WithNewPassword(newPassword, temporary)
                   .BuildPasswordChangeJson();
          }

          public async Task<bool> HasRequiredActionAsync(HttpClient client, string userId, string requiredAction)
          {
               var userByIdEndpoint = GetUserByIdEndpoint(_configuration, userId);
               var userResponse = await client.GetAsync(userByIdEndpoint);
               var userContent = await userResponse.Content.ReadAsStringAsync();

               if (!userResponse.IsSuccessStatusCode)
               {
                    throw new Exception($"Error al obtener el UserID: {userContent}");
               }

               var userJson = JsonDocument.Parse(userContent);
               var requiredActions = userJson.RootElement[0].GetProperty("requiredActions").EnumerateArray();
               foreach (var action in requiredActions)
               {
                    var actionString = action.GetString();
                    if (!string.IsNullOrEmpty(actionString) && actionString == requiredAction)
                    {
                         return true;
                    }
               }

               return false;
          }

          public IEnumerable<KeyValuePair<string, string>> BuildLogoutRequest(string refreshToken)
          {
               return _keycloakRequestBuilder
                   .WithClientId()
                   .WithClientSecret()
                   .WithRefreshToken(refreshToken)
                   .BuildAsForm();
          }

          public async Task<string?> GetClientIdAsync(HttpClient client)
          {
               var clientsEndpoint = _urlHelperKeycloak.GetClientsEndpoint(_configuration);
               var clientsResponse = await client.GetAsync(clientsEndpoint);
               var clientsContent = await clientsResponse.Content.ReadAsStringAsync();

               if (!clientsResponse.IsSuccessStatusCode)
               {
                    return null;
               }

               var clients = JsonDocument.Parse(clientsContent).RootElement;
               foreach (var clientElement in clients.EnumerateArray())
               {
                    if (clientElement.GetProperty("clientId").GetString() == _configuration["Keycloak:ClientId"])
                    {
                         return clientElement.GetProperty("id").GetString();
                    }
               }

               return null;
          }

          public async Task<JsonElement?> GetRoleAsync(HttpClient client, string clientId, string roleName)
          {
               var rolesEndpoint = _urlHelperKeycloak.GetClientRolesEndpoint(_configuration, clientId);
               var rolesResponse = await client.GetAsync(rolesEndpoint);
               var rolesContent = await rolesResponse.Content.ReadAsStringAsync();

               if (!rolesResponse.IsSuccessStatusCode)
               {
                    return null;
               }

               var roles = JsonDocument.Parse(rolesContent).RootElement;
               foreach (var roleElement in roles.EnumerateArray())
               {
                    if (roleElement.GetProperty("name").GetString() == roleName)
                    {
                         return roleElement;
                    }
               }

               return null;
          }

          public async Task<bool> AssignRoleAsync(HttpClient client, string userId, string clientId, string roleId, string roleName)
          {
               var roleEndpoint = _urlHelperKeycloak.GetRoleMappingsEndpoint(_configuration, userId, clientId);
               var roleRequestContent = _keycloakRequestBuilder.BuildAssignRoleJson(roleId, roleName);

               var response = await client.PostAsync(roleEndpoint, roleRequestContent);
               return response.IsSuccessStatusCode;
          }

          public async Task<bool> VerifyRoleAssignmentAsync(HttpClient client, string userId, string clientId, string roleId)
          {
               var verifyRoleEndpoint = _urlHelperKeycloak.GetRoleMappingsEndpoint(_configuration, userId, clientId);
               var verifyRoleResponse = await client.GetAsync(verifyRoleEndpoint);
               var verifyRoleContent = await verifyRoleResponse.Content.ReadAsStringAsync();

               if (!verifyRoleResponse.IsSuccessStatusCode)
               {
                    return false;
               }

               var assignedRoles = JsonDocument.Parse(verifyRoleContent).RootElement;
               foreach (var assignedRole in assignedRoles.EnumerateArray())
               {
                    if (assignedRole.GetProperty("id").GetString() == roleId)
                    {
                         return true;
                    }
               }

               return false;
          }

          public string GetUserEndpoint(IConfiguration configuration)
          {
               return _urlHelperKeycloak.GetUserEndpoint(configuration);
          }

          public string GetUserByIdEndpoint(IConfiguration configuration, string userId)
          {
               return _urlHelperKeycloak.GetUserByIdEndpoint(configuration, userId);
          }

          public string GetUserByEmailUrl(IConfiguration configuration, string email)
          {
               return _urlHelperKeycloak.GetUserByEmailUrl(configuration, email);
          }

          public string GetResetPasswordEndpoint(IConfiguration configuration, string userId)
          {
               return _urlHelperKeycloak.GetResetPasswordEndpoint(configuration, userId);
          }

          public string GetLogoutUrl(IConfiguration configuration)
          {
               return _urlHelperKeycloak.GetLogoutUrl(configuration);
          }
     }
}