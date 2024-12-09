using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API_GruasUCAB.Swagger
{
     public static class SwaggerConfiguration
     {
          public static void AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
          {
               var swaggerConfig = configuration.GetSection("Swagger").Get<SwaggerConfig>();

               services.AddSwaggerGen(c =>
               {
                    c.SwaggerDoc(swaggerConfig?.Version ?? string.Empty, new OpenApiInfo { Title = swaggerConfig?.Title ?? string.Empty, Version = swaggerConfig?.Version ?? string.Empty });
                    c.AddSecurityDefinition(swaggerConfig?.Authorization?.Scheme ?? string.Empty, new OpenApiSecurityScheme
                    {
                         Description = swaggerConfig?.Description ?? string.Empty,
                         Name = swaggerConfig?.Authorization?.Name ?? string.Empty,
                         In = Enum.TryParse<ParameterLocation>(swaggerConfig?.Authorization?.In, out var location) ? location : ParameterLocation.Header,
                         Type = Enum.TryParse<SecuritySchemeType>(swaggerConfig?.Authorization?.Type, out var type) ? type : SecuritySchemeType.ApiKey,
                         Scheme = swaggerConfig?.Authorization?.Scheme ?? string.Empty
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                   {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = swaggerConfig?.Authorization?.Scheme ?? string.Empty
                            },
                            Scheme = swaggerConfig?.Authorization?.Scheme ?? string.Empty,
                            Name = swaggerConfig?.Authorization?.Name ?? string.Empty,
                            In = location,
                        },
                        new string[] {}
                    }
                   });
               });
          }
     }
}