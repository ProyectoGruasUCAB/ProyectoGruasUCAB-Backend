namespace API_GruasUCAB.Core
{
     public static class CoreServiceRegistration
     {
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