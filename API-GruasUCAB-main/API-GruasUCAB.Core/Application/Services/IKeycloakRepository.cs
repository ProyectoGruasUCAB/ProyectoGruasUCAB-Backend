using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace API_GruasUCAB.Core.Infrastructure.KeycloakRepository
{
     public interface IKeycloakRepository
     {
          Task<TokenResponse?> GetTokenAsync(HttpClient client, string email, string password);
          Task<TokenResponse?> GetTokenAsync(HttpClient client, string clientId, string clientSecret, string grantType);
          Task<string> GetClientCredentialsTokenAsync(HttpClient client);
          Task<string?> IntrospectTokenAsync(HttpClient client, TokenIntrospectionRequestDTO request);
          StringContent BuildUserCreationJson(string email, string password);
          Task<string?> GetUserIdByEmailAsync(HttpClient client, string email);
          StringContent BuildPasswordChangeJson(string newPassword, bool temporary);
          Task<bool> HasRequiredActionAsync(HttpClient client, string userId, string requiredAction);
          IEnumerable<KeyValuePair<string, string>> BuildLogoutRequest(string refreshToken);
          Task<string?> GetClientIdAsync(HttpClient client);
          Task<JsonElement?> GetRoleAsync(HttpClient client, string clientId, string roleName);
          Task<bool> AssignRoleAsync(HttpClient client, string userId, string clientId, string roleId, string roleName);
          Task<bool> VerifyRoleAssignmentAsync(HttpClient client, string userId, string clientId, string roleId);
          string GetUserEndpoint(IConfiguration configuration);
          string GetUserByIdEndpoint(IConfiguration configuration, string userId);
          string GetUserByEmailUrl(IConfiguration configuration, string email);
          string GetResetPasswordEndpoint(IConfiguration configuration, string userId);
          string GetLogoutUrl(IConfiguration configuration);
     }
}