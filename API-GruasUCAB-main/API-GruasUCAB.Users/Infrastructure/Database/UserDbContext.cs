using API_GruasUCAB.Core.Infrastructure.Database;
using API_GruasUCAB.Users.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore.Storage;

namespace API_GruasUCAB.Users.Infrastructure.Database
{
    public class UserDbContext : DbContext, IUserDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbContext DbContext => this;

        public DbSet<Administrator> Administrators { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<Provider> Providers { get; set; } = null!;
        public DbSet<Worker> Workers { get; set; } = null!;

        public IDbContextTransaction BeginTransaction()
        {
            return Database.BeginTransaction();
        }

        public void ChangeEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class
        {
            if (entity != null)
            {
                Entry(entity).State = state;
            }
        }

        public async Task<bool> SaveEfContextChanges(CancellationToken cancellationToken = default)
        {
            return await SaveChangesAsync(cancellationToken) >= 0;
        }

        public async Task<bool> SaveEfContextChanges(string user, CancellationToken cancellationToken = default)
        {
            return await SaveChangesAsync(cancellationToken) >= 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AdministratorConfiguration());
            modelBuilder.ApplyConfiguration(new DriverConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());

            // Configuración de clave primaria de Administrador
            modelBuilder.Entity<Administrator>()
                .HasKey(c => c.Id);

            // Configuración de clave primaria de Driver
            modelBuilder.Entity<Driver>()
                .HasKey(c => c.Id);

            // Configuración de clave primaria de Provider
            modelBuilder.Entity<Provider>()
                .HasKey(c => c.Id);

            // Configuración de clave primaria de Worker
            modelBuilder.Entity<Worker>()
                .HasKey(c => c.Id);
        }
    }
}
