using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository;
using API_GruasUCAB.Auth.Infrastructure.Adapters.ClientCredentials;
using API_GruasUCAB.Auth.Infrastructure.DTOs.DeleteUser;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System;

namespace API_GruasUCAB.Auth.Infrastructure.Validators.DeleteUser
{
     public class AuthDeleteUserValidate : IService<DeleteUserRequestDTO, DeleteUserResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IHeadersClientCredentialsToken _headersClientCredentialsToken;

          public AuthDeleteUserValidate(IHttpClientFactory httpClientFactory, IConfiguration configuration, IKeycloakRepository keycloakRepository, IHeadersClientCredentialsToken headersClientCredentialsToken)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _keycloakRepository = keycloakRepository;
               _headersClientCredentialsToken = headersClientCredentialsToken;
          }

          public async Task<DeleteUserResponseDTO> Execute(DeleteUserRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();

               try
               {
                    //   client_credentials 
                    await _headersClientCredentialsToken.SetClientCredentialsToken(client);

                    //   Email => UserID
                    var (userId, _) = await _keycloakRepository.GetUserByEmailAsync(client, request.Email, string.Empty);

                    //   Delete User
                    var userDeleted = await _keycloakRepository.DeleteUserAsync(client, _configuration, userId);
                    if (!userDeleted)
                    {
                         throw new Exception("Error al eliminar el usuario.");
                    }

                    return new DeleteUserResponseDTO
                    {
                         Success = true,
                         Message = "User deleted successfully",
                         UserId = userId,
                         Time = DateTime.UtcNow
                    };
               }
               catch (UnauthorizedException ex)
               {
                    return new DeleteUserResponseDTO
                    {
                         Success = false,
                         Message = $"Unauthorized access: {ex.Message}",
                         Time = DateTime.UtcNow
                    };
               }
               catch (Exception ex)
               {
                    return new DeleteUserResponseDTO
                    {
                         Success = false,
                         Message = ex.Message,
                         Time = DateTime.UtcNow
                    };
               }
          }
     }
}