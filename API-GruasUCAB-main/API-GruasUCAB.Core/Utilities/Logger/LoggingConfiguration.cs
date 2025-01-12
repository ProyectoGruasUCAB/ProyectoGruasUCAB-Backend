namespace API_GruasUCAB.Core.Utilities.Logger
{
     public static class LoggingConfiguration
     {
          public static void ConfigureSerilog(WebApplicationBuilder builder)
          {
               Log.Logger = new LoggerConfiguration()
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                   .Enrich.FromLogContext()
                   .WriteTo.Console()
                   .WriteTo.File("Logs/app-.txt", rollingInterval: RollingInterval.Day)
                   .CreateLogger();

               builder.Host.UseSerilog();
          }

          public static void UseSerilogRequestLogging(this WebApplication app)
          {
               app.UseSerilogRequestLogging(options =>
               {
                    options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";
                    options.GetLevel = (httpContext, elapsedMs, ex) => ex != null || httpContext.Response.StatusCode > 499 ? LogEventLevel.Error : LogEventLevel.Information;
                    options.IncludeQueryInRequestPath = true;
               });
          }

          public static void RunLogger(this WebApplication app)
          {
               try
               {
                    Log.Information("Starting up");
                    app.Run();
               }
               catch (Exception ex)
               {
                    Log.Fatal(ex, "Application start-up failed");
               }
               finally
               {
                    Log.CloseAndFlush();
               }
          }
     }
}