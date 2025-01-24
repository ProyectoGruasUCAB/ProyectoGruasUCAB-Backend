using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using API_GruasUCAB.Policy.Infrastructure.Database.Configuration;
using API_GruasUCAB.Policy.Infrastructure.Adapters.Entities;

namespace API_GruasUCAB.Policy.Infrastructure.Database
{
    public class PolicyDbContext : DbContext
    {
        public PolicyDbContext(DbContextOptions<PolicyDbContext> options) : base(options) { }

        public DbContext DbContext => this;

        public DbSet<PolicyAggregate> Policies { get; set; } = null!;
        public DbSet<ClientAggregate> Clients { get; set; } = null!;

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
            modelBuilder.ApplyConfiguration(new ClientConfiguration());

            // Configuración de clave primaria de Policy
            modelBuilder.Entity<PolicyAggregate>()
                .HasKey(cd => cd.Id);

            modelBuilder.Entity<ClientAggregate>(entity =>
            {
                entity.HasKey(e => e.Id_cliente);
                entity.Property(e => e.Nombre_completo_cliente).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Cedula_cliente).IsRequired();
                entity.Property(e => e.Tlf_cliente).IsRequired();
                entity.Property(e => e.Fecha_nacimiento_cliente).IsRequired();
            });
        }
    }
}