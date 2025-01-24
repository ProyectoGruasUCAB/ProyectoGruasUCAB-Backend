using API_GruasUCAB.ServiceOrder.Domain.AggregateRoot;
using Microsoft.EntityFrameworkCore;
using API_GruasUCAB.ServiceOrder.Infrastructure.Database.Configuration;

namespace API_GruasUCAB.ServiceOrder.Infrastructure.Database
{
     public class ServiceOrderDbContext : DbContext
     {
          public ServiceOrderDbContext(DbContextOptions<ServiceOrderDbContext> options) : base(options) { }

          public DbSet<ServiceOrderAggregate> ServiceOrders { get; set; } = null!;

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);

               modelBuilder.ApplyConfiguration(new ServiceOrderConfiguration());

               // Configuración de clave primaria de ServiceOrder
               modelBuilder.Entity<ServiceOrderAggregate>()
                   .HasKey(so => so.Id);
          }
     }
}