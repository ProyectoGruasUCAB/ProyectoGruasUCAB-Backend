global using PolicyAggregate = API_GruasUCAB.Policy.Domain.AggregateRoot.Policy;
using API_GruasUCAB.Core.Infrastructure.Database;
using API_GruasUCAB.Policy.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using API_GruasUCAB.Policy.Domain.Entities;

namespace API_GruasUCAB.Policy.Infrastructure.Database
{
    public class PolicyDbContext : DbContext, IPolicyDbContext
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
            modelBuilder.ApplyConfiguration(new PolizaClienteConfiguration());

            // Configuración de clave primaria de policy
            modelBuilder.Entity<PolicyAggregate>()
                .HasKey(c => c.Id);

            // Configuración de clave primaria de Cliente
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id_cliente);

            // Configuración de la relación Poliza_Cliente
            modelBuilder.Entity<PolizaCliente>()
                .HasKey(pc => new { pc.PolicyId, pc.Id_cliente });

            modelBuilder.Entity<PolizaCliente>()
                .HasOne(pc => pc.Cliente)
                .WithMany(c => c.PolizaClientes)
                .HasForeignKey(pc => pc.Id_cliente);

            modelBuilder.Entity<PolizaCliente>()
                .HasOne(pc => pc.Policy)
                .WithMany(p => p.PolizaClientes)
                .HasForeignKey(pc => pc.PolicyId);
        }
    }
}