using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository;
using API_GruasUCAB.Users.Application.Services.Auth;
using System.Net.Http;
using System.Threading.Tasks;

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