using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace API_GruasUCAB.Swagger
{
     public class BearerTokenMiddleware
     {
          private readonly RequestDelegate _next;
          public BearerTokenMiddleware(RequestDelegate next)
          {
               _next = next;
          }
          public async Task InvokeAsync(HttpContext context)
          {
               if (context.Request.Headers.ContainsKey("Authorization"))
               {
                    var authHeader = context.Request.Headers["Authorization"].ToString();
                    if (!authHeader.StartsWith("Bearer "))
                    {
                         context.Request.Headers["Authorization"] = "Bearer " + authHeader;
                    }
               }
               await _next(context);
          }
     }
}