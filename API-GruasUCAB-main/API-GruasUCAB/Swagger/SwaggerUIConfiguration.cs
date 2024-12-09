using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace API_GruasUCAB.Swagger
{
     public static class SwaggerUIConfiguration
     {
          public static void UseSwaggerUIConfiguration(this IApplicationBuilder app, IHostEnvironment env, IConfiguration configuration)
          {
               var swaggerConfig = configuration.GetSection("Swagger").Get<SwaggerConfig>();

               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                         c.SwaggerEndpoint(swaggerConfig?.Endpoint ?? string.Empty, $"{swaggerConfig?.Title ?? string.Empty} {swaggerConfig?.Version ?? string.Empty}");
                         c.RoutePrefix = swaggerConfig?.RoutePrefix ?? string.Empty;
                    });
               }
          }
     }
}