using API_GruasUCAB.Vehicle.Domain.AggregateRoot;
using API_GruasUCAB.Vehicle.Domain.Entity;
using API_GruasUCAB.Vehicle.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace API_GruasUCAB.Vehicle.Infrastructure.Database
{
     public class VehicleDbContext : DbContext
     {
          public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) { }

          public DbSet<VehicleAggregate> Vehicles { get; set; } = null!;
          public DbSet<VehicleTypeAggregate> VehicleTypes { get; set; } = null!;

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

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);

               modelBuilder.ApplyConfiguration(new VehicleConfiguration());
               modelBuilder.ApplyConfiguration(new VehicleTypeConfiguration());

               // Configuración de clave primaria de Vehicle
               modelBuilder.Entity<VehicleAggregate>()
                   .HasKey(v => v.Id);

               // Configuración de clave primaria de VehicleType
               modelBuilder.Entity<VehicleType>()
                   .HasKey(vt => vt.Id);
          }
     }
}