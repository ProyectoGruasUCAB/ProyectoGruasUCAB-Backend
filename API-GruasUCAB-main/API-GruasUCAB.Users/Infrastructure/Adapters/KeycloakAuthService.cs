namespace API_GruasUCAB.Users.Infrastructure.Adapters.Auth
{
     public class KeycloakAuthService : IAuthService
     {
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IHttpClientFactory _httpClientFactory;

          public KeycloakAuthService(IKeycloakRepository keycloakRepository, IHttpClientFactory httpClientFactory)
          {
               _keycloakRepository = keycloakRepository;
               _httpClientFactory = httpClientFactory;
          }

          public async Task<(string UserId, string Role, string Email)> IntrospectTokenAsync(string token)
          {
               var client = _httpClientFactory.CreateClient();
               return await _keycloakRepository.IntrospectTokenAsync(client, token);
          }
     }
}