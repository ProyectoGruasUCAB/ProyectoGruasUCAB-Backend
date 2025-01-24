using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository.KeycloakRequestBuilder.DTO;

namespace API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository.KeycloakRequestBuilder
{
     public class KeycloakRequestBuilder : IKeycloakRequestBuilder
     {
          private readonly IConfiguration _configuration;
          private KeycloakRequestDTO _request;
          private Dictionary<string, object>? _newPassword;

          public KeycloakRequestBuilder(IConfiguration configuration)
          {
               _configuration = configuration;
               _request = new KeycloakRequestDTO();
          }

          public IKeycloakRequestBuilder WithToken(string token)
          {
               if (string.IsNullOrEmpty(token))
               {
                    throw new ConfigurationException("Token cannot be null or empty.");
               }
               _request.Token = token;
               return this;
          }

          public IKeycloakRequestBuilder WithRefreshToken(string refreshToken)
          {
               if (string.IsNullOrEmpty(refreshToken))
               {
                    throw new ConfigurationException("Refresh token cannot be null or empty.");
               }
               _request.RefreshToken = refreshToken;
               return this;
          }

          public IKeycloakRequestBuilder WithClientId()
          {
               var clientId = _configuration["Keycloak:ClientId"];
               if (string.IsNullOrEmpty(clientId))
               {
                    throw new ConfigurationException("ClientId configuration is missing for Keycloak.");
               }
               _request.ClientId = clientId;
               return this;
          }

          public IKeycloakRequestBuilder WithClientSecret()
          {
               var clientSecret = _configuration["Keycloak:ClientSecret"];
               if (string.IsNullOrEmpty(clientSecret))
               {
                    throw new ConfigurationException("ClientSecret configuration is missing for Keycloak.");
               }
               _request.ClientSecret = clientSecret;
               return this;
          }

          public IKeycloakRequestBuilder WithCredentials(string password, bool temporary)
          {
               if (string.IsNullOrEmpty(password))
               {
                    throw new ConfigurationException("Password cannot be null or empty.");
               }
               var credentials = new Dictionary<string, object>
               {
                    { "type", "password" },
                    { "value", password },
                    { "temporary", temporary }
               };
               _request.Credentials.Add(credentials);
               return this;
          }

          public IKeycloakRequestBuilder WithNewPassword(string password, bool temporary)
          {
               if (string.IsNullOrEmpty(password))
               {
                    throw new ConfigurationException("Password cannot be null or empty.");
               }
               _newPassword = new Dictionary<string, object>
               {
               { "type", "password" },
                    { "value", password },
                    { "temporary", temporary }
               };
               return this;
          }

          public IKeycloakRequestBuilder WithUsername(string username)
          {
               if (string.IsNullOrEmpty(username))
               {
                    throw new ConfigurationException("Username cannot be null or empty.");
               }
               _request.Username = username;
               return this;
          }

          public IKeycloakRequestBuilder WithEmail(string email)
          {
               if (string.IsNullOrEmpty(email))
               {
                    throw new ConfigurationException("Email cannot be null or empty.");
               }
               _request.Email = email;
               return this;
          }

          public IKeycloakRequestBuilder WithPassword(string password)
          {
               if (string.IsNullOrEmpty(password))
               {
                    throw new ConfigurationException("Password cannot be null or empty.");
               }
               _request.Password = password;
               return this;
          }

          public IKeycloakRequestBuilder WithGrantType(string grantType)
          {
               if (string.IsNullOrEmpty(grantType))
               {
                    throw new ConfigurationException("Grant type cannot be null or empty.");
               }
               _request.GrantType = grantType;
               return this;
          }

          public IKeycloakRequestBuilder WithEmailVerified(bool emailVerified)
          {
               _request.EmailVerified = emailVerified;
               return this;
          }

          public IKeycloakRequestBuilder WithEnabled(bool enabled)
          {
               _request.Enabled = enabled;
               return this;
          }

          public object GetUserData()
          {
               return new
               {
                    username = _request.Username,
                    email = _request.Email,
                    enabled = _request.Enabled,
                    emailVerified = _request.EmailVerified,
                    credentials = _request.Credentials
               };
          }
          public object GetRoleData(string roleId, string roleName)
          {
               return new[]
               {
                    new { id = roleId, name = roleName }
               };
          }

          public object GetNewPasswordData()
          {
               return new
               {
                    type = _newPassword?["type"],
                    value = _newPassword?["value"],
                    temporary = _newPassword?["temporary"]
               };
          }

          public IEnumerable<KeyValuePair<string, string>> BuildAsForm()
          {
               var formRequest = new Dictionary<string, string>();
               if (!string.IsNullOrEmpty(_request.Token)) formRequest["token"] = _request.Token;
               if (!string.IsNullOrEmpty(_request.RefreshToken)) formRequest["refresh_token"] = _request.RefreshToken;
               if (!string.IsNullOrEmpty(_request.ClientId)) formRequest["client_id"] = _request.ClientId;
               if (!string.IsNullOrEmpty(_request.ClientSecret)) formRequest["client_secret"] = _request.ClientSecret;
               if (!string.IsNullOrEmpty(_request.Username)) formRequest["username"] = _request.Username;
               if (!string.IsNullOrEmpty(_request.Email)) formRequest["email"] = _request.Email;
               if (!string.IsNullOrEmpty(_request.Password)) formRequest["password"] = _request.Password;
               if (!string.IsNullOrEmpty(_request.GrantType)) formRequest["grant_type"] = _request.GrantType;
               if (_request.EmailVerified.HasValue) formRequest["emailVerified"] = _request.EmailVerified.Value.ToString();
               if (_request.Enabled.HasValue) formRequest["enabled"] = _request.Enabled.Value.ToString();

               return formRequest;
          }

          public StringContent BuildJson(object data)
          {
               var json = JsonSerializer.Serialize(data);
               return new StringContent(json, Encoding.UTF8, "application/json");
          }
     }
}