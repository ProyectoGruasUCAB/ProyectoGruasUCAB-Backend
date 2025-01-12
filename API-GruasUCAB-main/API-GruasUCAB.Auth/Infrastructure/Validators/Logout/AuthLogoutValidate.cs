<<<<<<< HEAD
=======
using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository;
using API_GruasUCAB.Auth.Infrastructure.Adapters.HeadersToken;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Logout;
using API_GruasUCAB.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System;

>>>>>>> origin/Development
namespace API_GruasUCAB.Auth.Infrastructure.Validators.Logout
{
     public class AuthLogoutValidate : IService<LogoutRequestDTO, LogoutResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly HeadersToken _headersToken;

          public AuthLogoutValidate(IHttpClientFactory httpClientFactory, IConfiguration configuration, IKeycloakRepository keycloakRepository, HeadersToken headersToken)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _keycloakRepository = keycloakRepository;
               _headersToken = headersToken;
          }

          public async Task<LogoutResponseDTO> Execute(LogoutRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();
               try
               {
                    //   Logout
                    var success = await _keycloakRepository.LogoutAsync(client, _configuration, request.RefreshToken);

                    //   Introspect Token
                    _headersToken.SetAuthorizationHeader(client);
                    var token = _headersToken.GetToken();
                    var (userId, role, _) = await _keycloakRepository.IntrospectTokenAsync(client, token);

                    //   Token Active = Error
                    return new LogoutResponseDTO
                    {
                         Success = false,
                         Message = "Logout failed: Token is still active",
                         UserEmail = request.UserEmail,
                         Time = DateTime.UtcNow,
                         Active = true
                    };
               }
               catch (UnauthorizedAccessException)
               {
                    //   Token Inactive = Success
                    return new LogoutResponseDTO
                    {
                         Success = true,
                         Message = "Logout successful",
                         UserEmail = request.UserEmail,
                         Time = DateTime.UtcNow,
                         Active = false
                    };
               }
               catch (Exception ex)
               {
                    return new LogoutResponseDTO
                    {
                         Success = false,
                         Message = ex.Message,
                         UserEmail = request.UserEmail,
                         Time = DateTime.UtcNow,
                         Active = true
                    };
               }
          }
     }
}