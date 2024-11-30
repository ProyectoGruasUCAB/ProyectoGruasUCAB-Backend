using System.Collections.Generic;
using System.Net.Http;

namespace API_GruasUCAB.Core.Infrastructure.KeycloakRequestBuilder
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
          IEnumerable<KeyValuePair<string, string>> BuildAsForm();
          StringContent BuildUserCreationJson();
          StringContent BuildPasswordChangeJson();
          StringContent BuildPasswordChangeJsonWithCredentials();
          StringContent BuildAssignRoleJson(string roleId, string roleName);
     }
}