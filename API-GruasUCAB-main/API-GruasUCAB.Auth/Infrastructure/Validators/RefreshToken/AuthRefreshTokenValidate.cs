<<<<<<< HEAD
=======
using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository;
using API_GruasUCAB.Auth.Infrastructure.DTOs.RefreshToken;
using API_GruasUCAB.Core.Application.Services;
using System.Threading.Tasks;
using System.Net.Http;

>>>>>>> origin/Development
namespace API_GruasUCAB.Auth.Infrastructure.Validators.RefreshToken
{
     public class AuthRefreshTokenValidate : IService<RefreshTokenRequestDTO, RefreshTokenResponseDTO>
     {
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IHttpClientFactory _httpClientFactory;

          public AuthRefreshTokenValidate(IKeycloakRepository keycloakRepository, IHttpClientFactory httpClientFactory)
          {
               _keycloakRepository = keycloakRepository;
               _httpClientFactory = httpClientFactory;
          }

          public async Task<RefreshTokenResponseDTO> Execute(RefreshTokenRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();
               try
               {
                    //   Refresh Token
                    var (accessToken, refreshToken) = await _keycloakRepository.RefreshTokenAsync(client, request.RefreshToken);
                    return new RefreshTokenResponseDTO
                    {
                         Success = true,
                         Message = "Token refreshed successfully",
                         UserEmail = request.UserEmail,
                         Time = DateTime.UtcNow,
                         AccessToken = accessToken,
                         RefreshToken = refreshToken
                    };
               }
               catch (Exception ex)
               {
                    return new RefreshTokenResponseDTO
                    {
                         Success = false,
                         Message = ex.Message,
                         UserEmail = request.UserEmail,
                         Time = DateTime.UtcNow
                    };
               }
          }
     }
}