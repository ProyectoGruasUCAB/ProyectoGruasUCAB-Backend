using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository
{
     public interface IKeycloakRepository
     {
          //   Login
          Task<(string AccessToken, string RefreshToken)> GetTokenAsync(HttpClient client, string email, string password);

          //   Client Credentials
          Task<string> GetClientCredentialsTokenAsync(HttpClient client);

          //   Introspect Token
          Task<(string UserId, string Role, string Email)> IntrospectTokenAsync(HttpClient client, string token);

          //   Create User
          Task<bool> CreateUserAsync(HttpClient client, string email, string password);

          //   Email => UserID ^ RequiredAction?
          Task<(string UserId, bool HasRequiredAction)> GetUserByEmailAsync(HttpClient client, string email, string requiredAction);

          //   Change User Password
          Task<bool> ChangeUserPasswordAsync(HttpClient client, string userId, string newPassword, bool temporary);

          //   Reset Password
          Task<bool> ResetPasswordAsync(HttpClient client, string userId, string newPassword, bool temporary);

          //   Get Client ID
          Task<string> GetClientIdAsync(HttpClient client);

          //   Get Role by Name
          Task<string> GetRoleAsync(HttpClient client, string clientId, string roleName);

          //   Assign Role
          Task<bool> AssignRoleAsync(HttpClient client, string userId, string clientId, string roleId, string roleName);

          //   Verify Role Assignment
          Task<bool> VerifyRoleAssignmentAsync(HttpClient client, string userId, string clientId, string roleId);

          //   Delete User
          Task<bool> DeleteUserAsync(HttpClient client, IConfiguration configuration, string userId);
          //   Refresh Token
          Task<(string AccessToken, string RefreshToken)> RefreshTokenAsync(HttpClient client, string refreshToken);

          //   Logout
          Task<bool> LogoutAsync(HttpClient client, IConfiguration configuration, string refreshToken);
     }
}