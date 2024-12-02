
using Microsoft.EntityFrameworkCore; 
using backend.Domain.Entities;

namespace backend.Core.Database
{
    public interface IDbContext
    {
        DbContext DbContext { get; }

        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Rol> Roles { get; set; } 
        DbSet<Usuario_Rol> Usuario_Roles { get; set; } 
        DbSet<Trabajador> Trabajadores { get; set; } 
        DbSet<Proveedor> Proveedores { get; set; } 
        DbSet<Conductor> Conductores { get; set; } 
        DbSet<Departamento> Departamentos { get; set; }
        DbSet<Cliente> Clientes { get; set; } 
        DbSet<Poliza> Polizas { get; set; } 
        DbSet<Servicio> Servicios { get; set; } 
        DbSet<Estado> Estados { get; set; } 
        DbSet<Tipo_Vehiculo> Tipo_Vehiculos { get; set; } 
        DbSet<Lugar> Lugares { get; set; } 
        DbSet<Vehiculo> Vehiculos { get; set; }
        DbSet<Telefono> Telefonos { get; set; }
        DbSet<Poliza_Cliente> Poliza_Clientes { get; set; } 
        DbSet<Vehiculo_Proveedor> Vehiculo_Proveedores { get; set; }
        DbSet<Trabajador_Departamento> Trabajador_Departamentos { get; set; }
        DbSet<Orden_De_Servicio> Orden_De_Servicios { get; set; }
        DbSet<Servicio_Orden> Servicio_Ordenes { get; set; }
        DbSet<Estado_Orden> Estado_Ordenes { get; set; } 

        IDbContextTransactionProxy BeginTransaction();

        void ChangeEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class;

        Task<bool> SaveEfContextChanges(string user, CancellationToken cancellationToken = default);
    }
}
