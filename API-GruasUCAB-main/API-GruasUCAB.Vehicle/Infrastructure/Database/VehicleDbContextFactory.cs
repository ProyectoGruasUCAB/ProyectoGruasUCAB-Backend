using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace API_GruasUCAB.Vehicle.Infrastructure.Database
{
     public class VehicleDbContextFactory : IDesignTimeDbContextFactory<VehicleDbContext>
     {
          public VehicleDbContext CreateDbContext(string[] args)
          {
               IConfiguration configuration = new ConfigurationBuilder()
                   .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API-GruasUCAB"))
                   .AddJsonFile("appsettings.json")
                   .Build();

               var builder = new DbContextOptionsBuilder<VehicleDbContext>();
               var connectionString = configuration.GetConnectionString("DefaultConnection");

               builder.UseNpgsql(connectionString);

               return new VehicleDbContext(builder.Options);
          }
     }
}