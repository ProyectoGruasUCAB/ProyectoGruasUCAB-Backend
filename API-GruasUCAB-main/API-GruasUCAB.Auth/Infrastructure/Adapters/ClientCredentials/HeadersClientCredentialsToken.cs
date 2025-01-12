namespace API_GruasUCAB.Auth.Infrastructure.Adapters.ClientCredentials
{
     public class HeadersClientCredentialsToken : IHeadersClientCredentialsToken
     {
          private readonly IConfiguration _configuration;
          private readonly IKeycloakRepository _keycloakRepository;

          public HeadersClientCredentialsToken(IConfiguration configuration, IKeycloakRepository keycloakRepository)
          {
               _configuration = configuration;
               _keycloakRepository = keycloakRepository;
          }

          public async Task SetClientCredentialsToken(HttpClient client)
          {
               var accessToken = await _keycloakRepository.GetClientCredentialsTokenAsync(client);

               if (string.IsNullOrEmpty(accessToken))
               {
                    throw new UnauthorizedException("Error al obtener el access token utilizando client_credentials.");
               }

               var authType = _configuration["Keycloak:Auth_Type"];
               if (string.IsNullOrEmpty(authType))
               {
                    throw new ConfigurationException("Auth_Type configuration is missing for JwtBearer.");
               }

               //   Headers Client Credentials Token
               client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(authType, accessToken);
          }
     }
}