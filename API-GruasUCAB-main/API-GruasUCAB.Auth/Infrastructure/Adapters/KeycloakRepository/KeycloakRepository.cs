namespace API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository
{
     public class KeycloakRepository : IKeycloakRepository
     {
          private readonly IConfiguration _configuration;
          private readonly IUrlHelperKeycloak _urlHelperKeycloak;
          private readonly IKeycloakRequestBuilder _keycloakRequestBuilder;

          public KeycloakRepository(IConfiguration configuration, IUrlHelperKeycloak urlHelperKeycloak, IKeycloakRequestBuilder keycloakRequestBuilder)
          {
               _configuration = configuration;
               _urlHelperKeycloak = urlHelperKeycloak;
               _keycloakRequestBuilder = keycloakRequestBuilder;
          }

          //   Login
          public async Task<(string AccessToken, string RefreshToken)> GetTokenAsync(HttpClient client, string email, string password)
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
                    var error = JsonDocument.Parse(content).RootElement.GetProperty("error").GetString();

                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest && error == "invalid_grant" && errorDetails == "Account is not fully set up")
                    {
                         throw new UnauthorizedException("Account is not fully set up", new List<string> { errorDetails ?? "No additional details provided." });
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && error == "invalid_grant")
                    {
                         throw new UnauthorizedException("Invalid user credentials", new List<string> { errorDetails ?? "No additional details provided." });
                    }
                    else
                    {
                         throw new UnauthorizedException("Invalid credentials", new List<string> { errorDetails ?? "No additional details provided." });
                    }
               }

               var jsonDocument = JsonDocument.Parse(content);
               var root = jsonDocument.RootElement;

               var accessToken = root.GetProperty("access_token").GetString() ?? throw new UnauthorizedAccessException("Access token is null.");
               var refreshToken = root.GetProperty("refresh_token").GetString() ?? throw new UnauthorizedAccessException("Refresh token is null.");

               return (accessToken, refreshToken);
          }

          //   client_credentials
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
                    var errorDetails = JsonDocument.Parse(content).RootElement.GetProperty("error_description").GetString();
                    throw new UnauthorizedException("Error al obtener el access token utilizando client_credentials", new List<string> { errorDetails ?? "No additional details provided." });
               }

               var clientCredentialsJson = JsonDocument.Parse(content);
               var clientCredentialsRoot = clientCredentialsJson.RootElement;

               return clientCredentialsRoot.GetProperty("access_token").GetString() ?? string.Empty;
          }

          //   Introspect Token => UserID ^ Role ^ Email
          public async Task<(string UserId, string Role, string Email)> IntrospectTokenAsync(HttpClient client, string token)
          {
               var introspectEndpoint = _urlHelperKeycloak.GetIntrospectUrl(_configuration);

               var introspectRequestContent = _keycloakRequestBuilder
                   .WithToken(token)
                   .WithClientId()
                   .WithClientSecret()
                   .BuildAsForm();

               var introspectResponse = await client.PostAsync(introspectEndpoint, new FormUrlEncodedContent(introspectRequestContent));
               var introspectContent = await introspectResponse.Content.ReadAsStringAsync();

               if (!introspectResponse.IsSuccessStatusCode)
               {
                    var errorDetails = JsonDocument.Parse(introspectContent).RootElement.GetProperty("error_description").GetString();
                    throw new UnauthorizedAccessException($"Introspection failed: {errorDetails ?? "No additional details provided."}");
               }

               var introspectResult = JsonDocument.Parse(introspectContent).RootElement;

               if (!introspectResult.GetProperty("active").GetBoolean())
               {
                    throw new UnauthorizedAccessException("Token is inactive.");
               }

               var userId = introspectResult.GetProperty("sub").GetString() ?? throw new UnauthorizedAccessException("UserId is null.");
               var email = introspectResult.GetProperty("email").GetString() ?? throw new UnauthorizedAccessException("Email is null.");
               var clientId = _configuration["Keycloak:ClientId"] ?? throw new ConfigurationException("ClientId configuration is missing.");

               if (introspectResult.TryGetProperty("resource_access", out var resourceAccess) &&
                   resourceAccess.TryGetProperty(clientId, out var clientRoles) &&
                   clientRoles.TryGetProperty("roles", out var rolesArray) &&
                   rolesArray.GetArrayLength() == 1)
               {
                    var role = rolesArray[0].GetString() ?? throw new UnauthorizedAccessException("Role is null.");

                    // Allowed Roles
                    var allowedRoles = _configuration.GetSection("Roles").Get<List<string>>() ?? new List<string>();
                    if (allowedRoles.Contains(role))
                    {
                         return (userId, role, email);
                    }
                    throw new UnauthorizedAccessException($"Role '{role}' is not allowed.");
               }
               throw new UnauthorizedAccessException("Token does not contain exactly one role for the specified client.");
          }

          //   Create User
          public async Task<bool> CreateUserAsync(HttpClient client, string email, string password)
          {
               var userEndpoint = _urlHelperKeycloak.GetUserEndpoint(_configuration);
               _keycloakRequestBuilder
                   .WithUsername(email)
                   .WithEmail(email)
                   .WithCredentials(password, true)
                   .WithEnabled(true)
                   .WithEmailVerified(true);

               var userData = _keycloakRequestBuilder.GetUserData();
               var userRequestContent = _keycloakRequestBuilder.BuildJson(userData);

               var response = await client.PostAsync(userEndpoint, userRequestContent);
               var content = await response.Content.ReadAsStringAsync();
               if (!response.IsSuccessStatusCode)
               {
                    throw new UnauthorizedAccessException($"Error to create a new user: {content}"); ;
               }
               return true;
          }

          //   Email => UserID ^ RequiredAction?
          public async Task<(string UserId, bool HasRequiredAction)> GetUserByEmailAsync(HttpClient client, string email, string requiredAction)
          {
               var userByEmailUrl = _urlHelperKeycloak.GetUserByEmailUrl(_configuration, email);
               var userResponse = await client.GetAsync(userByEmailUrl);
               var userContent = await userResponse.Content.ReadAsStringAsync();
               if (!userResponse.IsSuccessStatusCode)
               {
                    throw new UnauthorizedAccessException($"Error al obtener el UserID: {userContent}");
               }

               var userJson = JsonDocument.Parse(userContent);
               if (userJson.RootElement.ValueKind == JsonValueKind.Array && userJson.RootElement.GetArrayLength() > 0)
               {
                    var userObject = userJson.RootElement[0];
                    var userId = userObject.GetProperty("id").GetString();
                    if (string.IsNullOrEmpty(userId))
                    {
                         throw new UnauthorizedAccessException("UserID is null or empty");
                    }

                    bool hasRequiredAction = false;
                    if (userObject.TryGetProperty("requiredActions", out var requiredActionsElement) && requiredActionsElement.ValueKind == JsonValueKind.Array)
                    {
                         var requiredActions = requiredActionsElement.EnumerateArray();
                         foreach (var action in requiredActions)
                         {
                              var actionString = action.GetString();
                              if (!string.IsNullOrEmpty(actionString) && actionString == requiredAction)
                              {
                                   hasRequiredAction = true;
                                   break;
                              }
                         }
                    }

                    return (userId, hasRequiredAction);
               }
               else
               {
                    throw new UnauthorizedAccessException("Expected an array but got an object or an empty array.");
               }
          }

          //   Change Password
          public async Task<bool> ChangeUserPasswordAsync(HttpClient client, string userId, string newPassword, bool temporary)
          {
               var userEndpoint = _urlHelperKeycloak.GetResetPasswordEndpoint(_configuration, userId);
               _keycloakRequestBuilder
                    .WithNewPassword(newPassword, temporary);

               var passwordData = _keycloakRequestBuilder.GetNewPasswordData();
               var passwordContent = _keycloakRequestBuilder.BuildJson(passwordData);

               var passwordResponse = await client.PutAsync(userEndpoint, passwordContent);
               var passwordResponseContent = await passwordResponse.Content.ReadAsStringAsync();

               if (!passwordResponse.IsSuccessStatusCode)
               {
                    throw new UnauthorizedAccessException($"The password could not be changed. Details: {passwordResponseContent}");
               }
               return true;
          }

          //   Reset Password
          public async Task<bool> ResetPasswordAsync(HttpClient client, string userId, string newPassword, bool temporary)
          {
               try
               {
                    var resetPasswordEndpoint = _urlHelperKeycloak.GetResetPasswordEndpoint(_configuration, userId);
                    var resetPasswordRequest = _keycloakRequestBuilder
                        .WithNewPassword(newPassword, temporary)
                        .BuildJson(_keycloakRequestBuilder.GetNewPasswordData());

                    var resetPasswordResponse = await client.PutAsync(resetPasswordEndpoint, resetPasswordRequest);
                    var resetPasswordContent = await resetPasswordResponse.Content.ReadAsStringAsync();

                    if (!resetPasswordResponse.IsSuccessStatusCode)
                    {
                         throw new Exception($"Error al resetear la contraseña: {resetPasswordContent}");
                    }

                    return true;
               }
               catch (UnauthorizedAccessException ex)
               {
                    throw new UnauthorizedAccessException($"Unauthorized access: {ex.Message}");
               }
               catch (Exception ex)
               {
                    throw new Exception($"Error al resetear la contraseña: {ex.Message}");
               }
          }

          //   Client ID
          public async Task<string> GetClientIdAsync(HttpClient client)
          {
               var clientsEndpoint = _urlHelperKeycloak.GetClientsEndpoint(_configuration);
               var clientsResponse = await client.GetAsync(clientsEndpoint);
               var clientsContent = await clientsResponse.Content.ReadAsStringAsync();
               if (!clientsResponse.IsSuccessStatusCode)
               {
                    if (clientsResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                         throw new UnauthorizedAccessException("Unauthorized access while trying to get client ID.");
                    }
                    throw new Exception($"Error while trying to get client ID: {clientsContent}");
               }
               var clients = JsonDocument.Parse(clientsContent).RootElement;
               foreach (var clientElement in clients.EnumerateArray())
               {
                    if (clientElement.GetProperty("clientId").GetString() == _configuration["Keycloak:ClientId"])
                    {
                         return clientElement.GetProperty("id").GetString() ?? throw new Exception("Client ID is null or empty.");
                    }
               }
               throw new Exception("Client ID not found.");
          }

          //   RoleName => RoleID
          public async Task<string> GetRoleAsync(HttpClient client, string clientId, string roleName)
          {
               var rolesEndpoint = _urlHelperKeycloak.GetClientRolesEndpoint(_configuration, clientId);
               var rolesResponse = await client.GetAsync(rolesEndpoint);
               var rolesContent = await rolesResponse.Content.ReadAsStringAsync();
               if (!rolesResponse.IsSuccessStatusCode)
               {
                    throw new Exception($"Error al obtener el rol: {rolesContent}");
               }

               var roles = JsonDocument.Parse(rolesContent).RootElement;
               foreach (var roleElement in roles.EnumerateArray())
               {
                    if (roleElement.GetProperty("name").GetString() == roleName)
                    {
                         return roleElement.GetProperty("id").GetString() ?? throw new Exception("Role ID is null or empty.");
                    }
               }
               throw new Exception("Role not found.");
          }

          //   Assign Role
          public async Task<bool> AssignRoleAsync(HttpClient client, string userId, string clientId, string roleId, string roleName)
          {
               var roleEndpoint = _urlHelperKeycloak.GetRoleMappingsEndpoint(_configuration, userId, clientId);
               var roleData = _keycloakRequestBuilder.GetRoleData(roleId, roleName);
               var roleRequestContent = _keycloakRequestBuilder.BuildJson(roleData);
               var response = await client.PostAsync(roleEndpoint, roleRequestContent);
               if (!response.IsSuccessStatusCode)
               {
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                         throw new UnauthorizedAccessException("Unauthorized access while trying to assign role.");
                    }
                    throw new Exception($"Error while trying to assign role: {await response.Content.ReadAsStringAsync()}");
               }
               return true;
          }

          //   Verify Role Assignment
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

          //   Delete User
          public async Task<bool> DeleteUserAsync(HttpClient client, IConfiguration configuration, string userId)
          {
               var deleteUserEndpoint = _urlHelperKeycloak.GetUserByIdEndpoint(configuration, userId);
               var deleteResponse = await client.DeleteAsync(deleteUserEndpoint);
               var deleteContent = await deleteResponse.Content.ReadAsStringAsync();

               if (!deleteResponse.IsSuccessStatusCode)
               {
                    throw new Exception($"Error al eliminar el usuario: {deleteContent}");
               }

               return true;
          }

          //   Refresh Token
          public async Task<(string AccessToken, string RefreshToken)> RefreshTokenAsync(HttpClient client, string refreshToken)
          {
               var tokenEndpoint = _urlHelperKeycloak.GetTokenUrl(_configuration);

               var refreshTokenRequest = _keycloakRequestBuilder
                   .WithClientId()
                   .WithClientSecret()
                   .WithGrantType("refresh_token")
                   .WithRefreshToken(refreshToken)
                   .BuildAsForm();

               var formContent = new FormUrlEncodedContent(refreshTokenRequest);
               var response = await client.PostAsync(tokenEndpoint, formContent);
               var content = await response.Content.ReadAsStringAsync();

               if (!response.IsSuccessStatusCode)
               {
                    var errorDetails = JsonDocument.Parse(content).RootElement.GetProperty("error_description").GetString();
                    throw new UnauthorizedException("Error al refrescar el token", new List<string> { errorDetails ?? "No additional details provided." });
               }

               var jsonDocument = JsonDocument.Parse(content);
               var root = jsonDocument.RootElement;

               var newAccessToken = root.GetProperty("access_token").GetString() ?? throw new UnauthorizedAccessException("Access token is null.");
               var newRefreshToken = root.GetProperty("refresh_token").GetString() ?? throw new UnauthorizedAccessException("Refresh token is null.");

               return (newAccessToken, newRefreshToken);
          }

          //   Logout
          public async Task<bool> LogoutAsync(HttpClient client, IConfiguration configuration, string refreshToken)
          {
               var logoutUrl = _urlHelperKeycloak.GetLogoutUrl(configuration);
               var logoutRequest = _keycloakRequestBuilder
                   .WithRefreshToken(refreshToken)
                   .WithClientId()
                   .WithClientSecret()
                   .BuildAsForm();

               var formContent = new FormUrlEncodedContent(logoutRequest);
               var response = await client.PostAsync(logoutUrl, formContent);
               var responseContent = await response.Content.ReadAsStringAsync();

               if (!response.IsSuccessStatusCode)
               {
                    throw new Exception($"Error al cerrar sesión: {responseContent}");
               }
               return true;
          }
     }
}