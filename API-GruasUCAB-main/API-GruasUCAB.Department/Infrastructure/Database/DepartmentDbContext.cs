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

               modelBuilder.Entity<DepartmentAggregate>()
                   .HasKey(d => d.Id);
          }
     }
}