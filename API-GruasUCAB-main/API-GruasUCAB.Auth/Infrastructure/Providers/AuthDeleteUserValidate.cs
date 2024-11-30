using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;
using API_GruasUCAB.Core.Infrastructure.ClientCredentials;
using API_GruasUCAB.Core.Infrastructure.KeycloakRepository;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System;

namespace API_GruasUCAB.Auth.Infrastructure.Providers
{
     public class AuthDeleteUserValidate : IService<DeleteUserRequestDTO, DeleteUserResponseDTO>
     {
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly IConfiguration _configuration;
          private readonly HeadersToken _headersToken;
          private readonly IHeadersClientCredentialsToken _headersClientCredentialsToken;
          private readonly IKeycloakRepository _keycloakRepository;

          public AuthDeleteUserValidate(IHttpClientFactory httpClientFactory, IConfiguration configuration, HeadersToken headersToken, IHeadersClientCredentialsToken headersClientCredentialsToken, IKeycloakRepository keycloakRepository)
          {
               _httpClientFactory = httpClientFactory;
               _configuration = configuration;
               _headersToken = headersToken;
               _headersClientCredentialsToken = headersClientCredentialsToken;
               _keycloakRepository = keycloakRepository;
          }

          public async Task<DeleteUserResponseDTO> Execute(DeleteUserRequestDTO request)
          {
               var client = _httpClientFactory.CreateClient();
               // Obtener y configurar el token del encabezado Authorization utilizando HeadersClientCredentialsToken
               await _headersClientCredentialsToken.SetClientCredentialsToken(client);
               var token = client.DefaultRequestHeaders.Authorization?.Parameter;

               // Obtener el ID del usuario utilizando el correo electrónico
               var userId = await _keycloakRepository.GetUserIdByEmailAsync(client, request.Email);

               if (string.IsNullOrEmpty(userId))
               {
                    return new DeleteUserResponseDTO { Success = false, Message = "UserID is null or empty" };
               }

               // Eliminar al usuario utilizando el ID
               var deleteUserEndpoint = _keycloakRepository.GetUserByIdEndpoint(_configuration, userId);
               var deleteResponse = await client.DeleteAsync(deleteUserEndpoint);
               var deleteContent = await deleteResponse.Content.ReadAsStringAsync();

               if (deleteResponse.IsSuccessStatusCode)
               {
                    return new DeleteUserResponseDTO { Success = true, Message = "User deleted successfully" };
               }
               else
               {
                    return new DeleteUserResponseDTO { Success = false, Message = deleteContent };
               }
          }
     }
}