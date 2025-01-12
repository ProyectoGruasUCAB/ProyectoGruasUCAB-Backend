namespace API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository.KeycloakRequestBuilder
{
     public interface IKeycloakRequestBuilder
     {
          IKeycloakRequestBuilder WithToken(string token);
          IKeycloakRequestBuilder WithRefreshToken(string refreshToken);
          IKeycloakRequestBuilder WithClientId();
          IKeycloakRequestBuilder WithClientSecret();
          IKeycloakRequestBuilder WithCredentials(string password, bool temporary);
          IKeycloakRequestBuilder WithNewPassword(string password, bool temporary);
          IKeycloakRequestBuilder WithUsername(string username);
          IKeycloakRequestBuilder WithEmail(string email);
          IKeycloakRequestBuilder WithPassword(string password);
          IKeycloakRequestBuilder WithGrantType(string grantType);
          IKeycloakRequestBuilder WithEmailVerified(bool emailVerified);
          IKeycloakRequestBuilder WithEnabled(bool enabled);
          object GetUserData();
          object GetNewPasswordData();
          object GetRoleData(string roleId, string roleName);
          IEnumerable<KeyValuePair<string, string>> BuildAsForm();
          StringContent BuildJson(object data);
     }
}