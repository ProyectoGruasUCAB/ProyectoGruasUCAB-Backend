using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.KeycloakRepository;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace API_GruasUCAB.Auth.Infrastructure.Providers
{
     public class AuthLogoutValidate : IService<LogoutRequestDTO, LogoutResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly IKeycloakRepository _keycloakRepository;

          public AuthLogoutValidate(IHttpClientFactory httpClientFactory, IConfiguration configuration, IKeycloakRepository keycloakRepository)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _keycloakRepository = keycloakRepository;
          }

          public async Task<LogoutResponseDTO> Execute(LogoutRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();
               var logoutEndpoint = _keycloakRepository.GetLogoutUrl(_configuration);

               var logoutRequest = _keycloakRepository.BuildLogoutRequest(request.RefreshToken);

               if (logoutRequest == null || !(logoutRequest is IEnumerable<KeyValuePair<string, string>>))
               {
                    throw new ConfigurationException("Logout request is null or invalid");
               }

               var formContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)logoutRequest);

               var response = await client.PostAsync(logoutEndpoint, formContent);
               var content = await response.Content.ReadAsStringAsync();

               if (response.IsSuccessStatusCode)
               {
                    return new LogoutResponseDTO
                    {
                         Message = "Logged out successfully"
                    };
               }

               var errorDetails = JsonDocument.Parse(content).RootElement.GetProperty("error_description").GetString();
               var errors = new List<string> { errorDetails ?? "No additional details provided." };
               throw new UnauthorizedException("Logout failed", errors);
          }
     }
}