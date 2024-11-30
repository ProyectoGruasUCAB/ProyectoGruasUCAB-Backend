using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Core.Infrastructure.HeadersToken;
using API_GruasUCAB.Core.Infrastructure.KeycloakRepository;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System;

namespace API_GruasUCAB.Auth.Infrastructure.Providers
{
    public class AuthLoginValidate : IService<LoginRequestDTO, LoginResponseDTO>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly HeadersToken _headersToken;
        private readonly IKeycloakRepository _keycloakRepository;

        public AuthLoginValidate(IHttpClientFactory httpClientFactory, IConfiguration configuration, HeadersToken headersToken, IKeycloakRepository keycloakRepository)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _headersToken = headersToken;
            _keycloakRepository = keycloakRepository;
        }

        public async Task<LoginResponseDTO> Execute(LoginRequestDTO request)
        {
            var client = _httpClientFactory.CreateClient();
            var tokenResponse = await _keycloakRepository.GetTokenAsync(client, request.Email, request.Password);

            if (tokenResponse == null || string.IsNullOrEmpty(tokenResponse.AccessToken))
            {
                throw new UnauthorizedException("Invalid credentials", new List<string> { "Invalid credentials" });
            }

            // Verificar que el esquema de autorización no sea nulo
            var authType = _configuration["Keycloak:Auth_Type"];
            if (string.IsNullOrEmpty(authType))
            {
                throw new ConfigurationException("Auth_Type configuration is missing for JwtBearer.");
            }

            // Establecer el encabezado de autorización utilizando el token de acceso
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(authType, tokenResponse.AccessToken);

            // Introspeccionar el token para obtener el UserID
            var introspectionRequest = new TokenIntrospectionRequestDTO
            {
                Token = tokenResponse.AccessToken
            };

            var userId = await _keycloakRepository.IntrospectTokenAsync(client, introspectionRequest);

            if (string.IsNullOrEmpty(userId))
            {
                Console.WriteLine($"Introspection result: {userId}");
                throw new UnauthorizedAccessException("Token is null or empty.");
            }

            return new LoginResponseDTO
            {
                Token = tokenResponse.AccessToken,
                RefreshToken = tokenResponse.RefreshToken ?? string.Empty,
                UserID = userId
            };
        }
    }
}