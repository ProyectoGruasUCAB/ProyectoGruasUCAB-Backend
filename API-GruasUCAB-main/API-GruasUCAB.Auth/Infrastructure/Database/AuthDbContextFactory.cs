namespace API_GruasUCAB.Auth.Infrastructure.Database
{
     public class AuthDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
     {
          public AuthDbContext CreateDbContext(string[] args)
          {
               IConfiguration configuration = new ConfigurationBuilder()
                   .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API-GruasUCAB"))
                   .AddJsonFile("appsettings.json")
                   .Build();

               var builder = new DbContextOptionsBuilder<AuthDbContext>();
               var connectionString = configuration.GetConnectionString("DefaultConnection");

               builder.UseNpgsql(connectionString);

               return new AuthDbContext(builder.Options);
          }
     }
}