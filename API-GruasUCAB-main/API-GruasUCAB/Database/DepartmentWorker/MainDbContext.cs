global using DepartmentAggregate = API_GruasUCAB.Department.Domain.AggregateRoot.Department;
global using DepartmentWorkerAli = API_GruasUCAB.Database.DepartmentWorker.Entities.DepartmentWorker;

namespace API_GruasUCAB.Database.DepartmentWorker
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        public DbSet<Worker> Workers { get; set; } = null!;
        public DbSet<DepartmentAggregate> Departments { get; set; } = null!;
        public DbSet<DepartmentWorkerAli> DepartmentWorkers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DepartmentWorkerConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            // Configuración de clave primaria de Worker
            modelBuilder.Entity<Worker>()
                .HasKey(c => c.Id);

            // Configuración de clave primaria de Department
            modelBuilder.Entity<DepartmentAggregate>()
                .HasKey(c => c.Id);
        }
    }
}