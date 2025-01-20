using Microsoft.EntityFrameworkCore.Design;

namespace API_GruasUCAB.Database.DepartmentWorker
{
     public class MainDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
     {
          public MainDbContext CreateDbContext(string[] args)
          {
               var optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();

               IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

               var connectionString = configuration.GetConnectionString("DefaultConnection");
               optionsBuilder.UseNpgsql(connectionString);

               return new MainDbContext(optionsBuilder.Options);
          }
     }
}