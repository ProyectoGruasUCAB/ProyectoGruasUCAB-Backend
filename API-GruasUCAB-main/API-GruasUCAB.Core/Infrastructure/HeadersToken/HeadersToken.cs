using Microsoft.Extensions.Configuration;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Linq;

namespace API_GruasUCAB.Core.Infrastructure.HeadersToken
{
     public class HeadersToken
     {
          private readonly IHttpContextAccessor _httpContextAccessor;
          private readonly IConfiguration _configuration;

          public HeadersToken(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
          {
               _httpContextAccessor = httpContextAccessor;
               _configuration = configuration;
          }

          public string GetToken()
          {
               var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
               if (string.IsNullOrEmpty(token))
               {
                    throw new UnauthorizedException("Token no proporcionado");
               }
               return token;
          }

          public void SetAuthorizationHeader(HttpClient client)
          {
               var token = GetToken();
               var authType = _configuration["Keycloak:Auth_Type"];
               if (string.IsNullOrEmpty(authType))
               {
                    throw new ConfigurationException("Auth_Type configuration is missing for JwtBearer.");
               }
               client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(authType, token);
          }
     }
}