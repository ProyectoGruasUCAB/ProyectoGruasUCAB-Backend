using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository;
using API_GruasUCAB.Auth.Infrastructure.DTOs.ChangePassword;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System;

namespace API_GruasUCAB.Auth.Infrastructure.Validators.ChangePassword
{
     public class AuthChangePasswordValidator : IService<ChangePasswordRequestDTO, ChangePasswordResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly HeadersToken _headersToken;
          private readonly IKeycloakRepository _keycloakRepository;

          public AuthChangePasswordValidator(IHttpClientFactory httpClientFactory, IConfiguration configuration, HeadersToken headersToken, IKeycloakRepository keycloakRepository)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _headersToken = headersToken;
               _keycloakRepository = keycloakRepository;
          }

          public async Task<ChangePasswordResponseDTO> Execute(ChangePasswordRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();
               bool temporaryPassword = false;
               var token = _headersToken.GetToken();
               _headersToken.SetAuthorizationHeader(client);

               try
               {
                    // Introspect Token
                    (string userId, string role) = await _keycloakRepository.IntrospectTokenAsync(client, token);

                    // Change Password
                    var passwordChanged = await _keycloakRepository.ChangeUserPasswordAsync(client, userId, request.NewPassword, temporaryPassword);
                    if (!passwordChanged)
                    {
                         throw new Exception("Error changing password.");
                    }

                    return new ChangePasswordResponseDTO
                    {
                         Success = true,
                         Message = "Password changed successfully",
                         TemporaryPassword = temporaryPassword,
                         Time = DateTime.UtcNow
                    };
               }
               catch (UnauthorizedAccessException ex)
               {
                    return new ChangePasswordResponseDTO
                    {
                         Success = false,
                         Message = $"Unauthorized access: {ex.Message}",
                         Time = DateTime.UtcNow
                    };
               }
               catch (Exception ex)
               {
                    return new ChangePasswordResponseDTO
                    {
                         Success = false,
                         Message = ex.Message,
                         Time = DateTime.UtcNow
                    };
               }
          }
     }
}