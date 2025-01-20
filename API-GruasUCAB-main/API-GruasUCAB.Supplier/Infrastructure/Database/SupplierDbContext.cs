using API_GruasUCAB.Core.Infrastructure.Database;
using API_GruasUCAB.Supplier.Domain.AggregateRoot;
using API_GruasUCAB.Supplier.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace API_GruasUCAB.Supplier.Infrastructure.Database
{
     public class SupplierDbContext : DbContext, IUserDbContext
     {
          public SupplierDbContext(DbContextOptions<SupplierDbContext> options) : base(options) { }

          public DbContext DbContext => this;

          public DbSet<SupplierAggregate> Suppliers { get; set; } = null!;

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

               modelBuilder.ApplyConfiguration(new SupplierConfiguration());

               // Configuración de clave primaria de Supplier
               modelBuilder.Entity<SupplierAggregate>()
                   .HasKey(c => c.Id);
          }
     }
}