using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace API_GruasUCAB.Auth.Infrastructure.Adapters.HeadersToken
{
     public class HeadersToken
     {
          private readonly IHttpContextAccessor _httpContextAccessor;

          public HeadersToken(IHttpContextAccessor httpContextAccessor)
          {
               _httpContextAccessor = httpContextAccessor;
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