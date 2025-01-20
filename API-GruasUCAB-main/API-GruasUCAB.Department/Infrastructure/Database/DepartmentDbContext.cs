using API_GruasUCAB.Department.Domain.AggregateRoot;
using Microsoft.EntityFrameworkCore;
using API_GruasUCAB.Department.Infrastructure.Database.Configuration;

namespace API_GruasUCAB.Department.Infrastructure.Database
{
     public class DepartmentDbContext : DbContext
     {
          public DepartmentDbContext(DbContextOptions<DepartmentDbContext> options) : base(options) { }

          public DbSet<DepartmentAggregate> Departments { get; set; } = null!;

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);

               modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

               // Configuración de clave primaria de Department
               modelBuilder.Entity<DepartmentAggregate>()
                   .HasKey(d => d.Id);
          }
     }
}