using Microsoft.Extensions.Configuration;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Linq;
using System.Net.Http.Headers;

namespace API_GruasUCAB.Auth.Infrastructure.Adapters.HeadersToken
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
               var context = _httpContextAccessor.HttpContext;
               if (context == null)
               {
                    throw new InvalidOperationException("HttpContext is null.");
               }

               var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
               if (string.IsNullOrEmpty(authorizationHeader))
               {
                    throw new InvalidOperationException("Authorization header is missing.");
               }

               var token = authorizationHeader.Split(" ").Last();
               if (string.IsNullOrEmpty(token))
               {
                    throw new InvalidOperationException("Token is missing.");
               }

               return token;
          }

          public void SetAuthorizationHeader(HttpClient client)
          {
               var token = GetToken();
               client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          }
     }
}