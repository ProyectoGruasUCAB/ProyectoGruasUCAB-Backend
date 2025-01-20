using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace API_GruasUCAB.Department.Infrastructure.Database
{
     public class DepartmentDbContextFactory : IDesignTimeDbContextFactory<DepartmentDbContext>
     {
          public DepartmentDbContext CreateDbContext(string[] args)
          {
               IConfiguration configuration = new ConfigurationBuilder()
                   .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API-GruasUCAB"))
                   .AddJsonFile("appsettings.json")
                   .Build();

               var builder = new DbContextOptionsBuilder<DepartmentDbContext>();
               var connectionString = configuration.GetConnectionString("DefaultConnection");

               builder.UseNpgsql(connectionString);

               return new DepartmentDbContext(builder.Options);
          }
     }
}