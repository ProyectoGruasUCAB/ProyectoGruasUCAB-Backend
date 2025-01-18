using API_GruasUCAB.Users.Domain.Entities;
using API_GruasUCAB.Users.Core.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace API_GruasUCAB.Users.Infrastructure.Database
{
    public class UserDbContext : DbContext, IUserDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbContext DbContext
        {
            get { return this; }
        }

        public DbSet<Administrator> Administrators { get; set; } = null!;
        //public DbSet<Driver> Drivers { get; set; } = null!;
        //public DbSet<Supplier> Suppliers { get; set; } = null!;
        //public DbSet<Worker> Workers { get; set; } = null!;

        public IDbContextTransactionProxy BeginTransaction()
        {
            return new DbContextTransactionProxy(this);
        }

        public virtual void ChangeEntityState<TEntity>(TEntity entity, EntityState state)
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

        public async Task<bool> SaveEfContextChanges(
            string user,
            CancellationToken cancellationToken = default
        )
        {
            return await SaveChangesAsync(cancellationToken) >= 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de clave primaria de Conductor
            modelBuilder.Entity<Administrator>()
                .HasKey(c => c.Id);


            // Configuración de clave primaria de Rol
            modelBuilder.Entity<Driver>()
                .HasKey(c => c.Id);


            // Configuración de clave primaria de Trabajador
            modelBuilder.Entity<Supplier>()
                .HasKey(c => c.Id);

            // Configuración de clave primaria de Usuario
            modelBuilder.Entity<Worker>()
                .HasKey(c => c.Id);

            base.OnModelCreating(modelBuilder);


        }
    }
}
