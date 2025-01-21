using API_GruasUCAB.ServiceFee.Domain.AggregateRoot;
using API_GruasUCAB.ServiceFee.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace API_GruasUCAB.ServiceFee.Infrastructure.Database
{
     public class ServiceFeeDbContext : DbContext
     {
          public ServiceFeeDbContext(DbContextOptions<ServiceFeeDbContext> options) : base(options) { }

          public DbSet<ServiceFeeAggregate> ServiceFees { get; set; } = null!;

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);

               modelBuilder.ApplyConfiguration(new ServiceFeeConfiguration());

               // Configuración de clave primaria de ServiceFee
               modelBuilder.Entity<ServiceFeeAggregate>()
                   .HasKey(sf => sf.Id);
          }
     }
}