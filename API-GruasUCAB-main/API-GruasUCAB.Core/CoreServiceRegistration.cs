<<<<<<< HEAD
=======
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using API_GruasUCAB.Core.Utilities.Logger;

>>>>>>> origin/Development
namespace API_GruasUCAB.Core
{
     public static class CoreServiceRegistration
     {
<<<<<<< HEAD
=======
          public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
          {
          }

>>>>>>> origin/Development
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