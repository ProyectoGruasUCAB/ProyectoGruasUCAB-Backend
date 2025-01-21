using Microsoft.EntityFrameworkCore.Design;

namespace API_GruasUCAB.Policy.Infrastructure.Database
{
    public class PolicyDbContextFactory : IDesignTimeDbContextFactory<PolicyDbContext>
    {
        public PolicyDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API-GruasUCAB"))
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PolicyDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseNpgsql(connectionString);

            return new PolicyDbContext(builder.Options);
        }
    }
}