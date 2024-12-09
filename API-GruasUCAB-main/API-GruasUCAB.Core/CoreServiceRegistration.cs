using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using API_GruasUCAB.Core.Utilities.Logger;

namespace API_GruasUCAB.Core
{
     public static class CoreServiceRegistration
     {
          public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
          {
          }

          public static void ConfigureLogging(WebApplicationBuilder builder)
          {
               LoggingConfiguration.ConfigureSerilog(builder);
          }

          public static void UseLogging(WebApplication app)
          {
               LoggingConfiguration.UseSerilogRequestLogging(app);
          }
     }
}