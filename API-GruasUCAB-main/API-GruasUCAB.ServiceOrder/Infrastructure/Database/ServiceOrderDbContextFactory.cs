using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace API_GruasUCAB.ServiceOrder.Infrastructure.Database
{
     public class ServiceOrderDbContextFactory : IDesignTimeDbContextFactory<ServiceOrderDbContext>
     {
          public ServiceOrderDbContext CreateDbContext(string[] args)
          {
               IConfiguration configuration = new ConfigurationBuilder()
                   .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API-GruasUCAB"))
                   .AddJsonFile("appsettings.json")
                   .Build();

               var builder = new DbContextOptionsBuilder<ServiceOrderDbContext>();
               var connectionString = configuration.GetConnectionString("DefaultConnection");

               builder.UseNpgsql(connectionString);

               return new ServiceOrderDbContext(builder.Options);
          }
     }
}