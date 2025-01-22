using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace API_GruasUCAB.ServiceFee.Infrastructure.Database
{
     public class ServiceFeeDbContextFactory : IDesignTimeDbContextFactory<ServiceFeeDbContext>
     {
          public ServiceFeeDbContext CreateDbContext(string[] args)
          {
               IConfiguration configuration = new ConfigurationBuilder()
                   .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API-GruasUCAB"))
                   .AddJsonFile("appsettings.json")
                   .Build();

               var builder = new DbContextOptionsBuilder<ServiceFeeDbContext>();
               var connectionString = configuration.GetConnectionString("DefaultConnection");

               builder.UseNpgsql(connectionString);

               return new ServiceFeeDbContext(builder.Options);
          }
     }
}