using Microsoft.EntityFrameworkCore.Storage;

namespace API_GruasUCAB.Policy.Infrastructure.Database
{
    public class PolicyDbContext : DbContext
    {
        public PolicyDbContext(DbContextOptions<PolicyDbContext> options) : base(options) { }

        public DbContext DbContext => this;

        public DbSet<PolicyAggregate> Policies { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;

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

            modelBuilder.ApplyConfiguration(new PolicyConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());

            // Configuración de clave primaria de Policy
            modelBuilder.Entity<PolicyAggregate>()
                .HasKey(c => c.Id);

            // Configuración de clave primaria de Client
            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id_cliente);
        }
    }
}