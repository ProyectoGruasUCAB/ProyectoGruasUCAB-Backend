namespace API_GruasUCAB.Auth.Infrastructure.Database
{
     public class AuthDbContext : DbContext
     {
          public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

          public DbSet<NewWorker> NewWorkers { get; set; } = null!;
          public DbSet<NewProvider> NewProviders { get; set; } = null!;
          public DbSet<NewDriver> NewDrivers { get; set; } = null!;

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);

               modelBuilder.ApplyConfiguration(new NewWorkerConfiguration());
               modelBuilder.ApplyConfiguration(new NewProviderConfiguration());
               modelBuilder.ApplyConfiguration(new NewDriverConfiguration());

               modelBuilder.Entity<NewWorker>()
                    .HasKey(d => d.WorkerId);

               modelBuilder.Entity<NewProvider>()
                    .HasKey(d => d.ProviderId);

               modelBuilder.Entity<NewDriver>()
                    .HasKey(d => d.DriverId);
          }
     }
}