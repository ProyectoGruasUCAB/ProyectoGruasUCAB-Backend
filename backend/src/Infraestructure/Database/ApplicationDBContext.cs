
//using backend.Core.Database;
using backend.Domain.Entities;
using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace backend.Infraestructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbContext DbContext
        {
            get { return this; }
        }

        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Rol> Roles { get; set; } = null!;
        public virtual DbSet<Usuario_Rol> Usuario_Roles { get; set; } = null!;
        public virtual DbSet<Trabajador> Trabajadores { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedores { get; set; } = null!;
        public virtual DbSet<Conductor> Conductores { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Poliza> Polizas { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Tipo_Vehiculo> Tipo_Vehiculos { get; set; } = null!;
        public virtual DbSet<Lugar> Lugares { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;
        public virtual DbSet<Telefono> Telefonos { get; set; } = null!;
        public virtual DbSet<Poliza_Cliente> Poliza_Clientes { get; set; } = null!;
        public virtual DbSet<Vehiculo_Proveedor> Vehiculo_Proveedores { get; set; } = null!;
        public virtual DbSet<Trabajador_Departamento> Trabajador_Departamentos { get; set; } = null!;
        public virtual DbSet<Orden_De_Servicio> Orden_De_Servicios { get; set; } = null!;
        public virtual DbSet<Servicio_Orden> Servicio_Ordenes { get; set; } = null!;
        public virtual DbSet<Estado_Orden> Estado_Ordenes { get; set; } = null!;
    

         protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Configuración de clave primaria de Cliente
            modelBuilder.Entity<Cliente>() 
                .HasKey(c => c.Id_cliente);

            // Configuración de clave primaria de Conductor
            modelBuilder.Entity<Conductor>() 
                .HasKey(c => c.Id_conductor);

            // Configuración de clave primaria de Departamento
            modelBuilder.Entity<Departamento>() 
                .HasKey(c => c.Id_departamento);

            // Configuración de clave primaria de Estado
            modelBuilder.Entity<Estado>() 
                .HasKey(c => c.Id_estado);

            // Configuración de clave primaria de Lugar
            modelBuilder.Entity<Lugar>() 
                .HasKey(c => c.Id_lugar);

            // Configuración de clave primaria de Orden_De_Servicio
            modelBuilder.Entity<Orden_De_Servicio>() 
                .HasKey(c => c.Id_orden_de_servicio);

            // Configuración de clave primaria de Poliza
            modelBuilder.Entity<Poliza>() 
                .HasKey(c => c.Id_poliza);

            // Configuración de clave primaria de Proveedor
            modelBuilder.Entity<Proveedor>() 
                .HasKey(c => c.Id_proveedor);

            // Configuración de clave primaria de Rol
            modelBuilder.Entity<Rol>() 
                .HasKey(c => c.Id_rol);

            // Configuración de clave primaria de Servicio
            modelBuilder.Entity<Servicio>() 
                .HasKey(c => c.Id_servicio);

            // Configuración de clave primaria de Telefono
            modelBuilder.Entity<Telefono>() 
                .HasKey(c => c.Id_tlf);

            // Configuración de clave primaria de Tipo_Vehiculo
            modelBuilder.Entity<Tipo_Vehiculo>() 
                .HasKey(c => c.Id_tipo_vehiculo);

            // Configuración de clave primaria de Trabajador
            modelBuilder.Entity<Trabajador>() 
                .HasKey(c => c.Id_trabajador);

            // Configuración de clave primaria de Usuario
            modelBuilder.Entity<Usuario>() 
                .HasKey(c => c.Id_usuario);

            // Configuración de clave primaria de Vehiculo
            modelBuilder.Entity<Vehiculo>() 
                .HasKey(c => c.Id_vehiculo);

            // Configuración de Usuario_Rol
            modelBuilder.Entity<Usuario_Rol>()
                .HasKey(ur => new { ur.Id_usuario, ur.Id_rol});

            modelBuilder.Entity<Usuario_Rol>()
                .HasOne(ur => ur.Usuario)
                .WithMany(u => u.Usuario_Roles)
                .HasForeignKey(ur => ur.Id_usuario);

            modelBuilder.Entity<Usuario_Rol>()
                .HasOne(ur => ur.Rol)
                .WithMany(r => r.Usuario_Roles)
                .HasForeignKey(ur => ur.Id_rol);

            // Configuración de las relaciones de Usuario
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Trabajador)
                .WithOne()
                .HasForeignKey<Usuario>(u => u.Id_trabajador);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Conductor)
                .WithOne()
                .HasForeignKey<Usuario>(u => u.Id_conductor);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Proveedor)
                .WithOne()
                .HasForeignKey<Usuario>(u => u.Id_proveedor);

            // Configuración de Lugar fk_lugar
            modelBuilder.Entity<Lugar>()
                .HasOne(l => l.LugarPadre)
                .WithMany(l => l.LugaresHijos)
                .HasForeignKey(l => l.LugarPadreId);

            // Configuración de la relación Vehiculo con Tipo_Vehiculo
            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Tipo_Vehiculo)
                .WithMany(tv => tv.Vehiculos)
                .HasForeignKey(v => v.Id_tipo_vehiculo);

            // Configuración de las relaciones de Telefono
            modelBuilder.Entity<Telefono>()
                .HasOne(t => t.Trabajador)
                .WithMany(t => t.Telefonos)
                .HasForeignKey(t => t.Id_trabajador);

            modelBuilder.Entity<Telefono>()
                .HasOne(t => t.Conductor)
                .WithMany(c => c.Telefonos)
                .HasForeignKey(t => t.Id_conductor);

            modelBuilder.Entity<Telefono>()
                .HasOne(t => t.Cliente)
                .WithMany(c => c.Telefonos)
                .HasForeignKey(t => t.Id_cliente);

            // Configuración de la relación Poliza_Cliente
            modelBuilder.Entity<Poliza_Cliente>()
                .HasKey(pc => new { pc.Id_poliza_cliente, pc.Id_cliente, pc.Id_poliza });

            modelBuilder.Entity<Poliza_Cliente>()
                .HasOne(pc => pc.Cliente)
                .WithMany(c => c.Poliza_Clientes)
                .HasForeignKey(pc => pc.Id_cliente);

            modelBuilder.Entity<Poliza_Cliente>()
                .HasOne(pc => pc.Poliza)
                .WithMany(p => p.Poliza_Clientes)
                .HasForeignKey(pc => pc.Id_poliza);

            // Configuración de la relación Vehiculo_Proveedor
            modelBuilder.Entity<Vehiculo_Proveedor>()
                .HasKey(vp => new { vp.Id_vehiculo_proveedor, vp.Id_proveedor, vp.Id_vehiculo });

            modelBuilder.Entity<Vehiculo_Proveedor>()
                .HasOne(vp => vp.Proveedor)
                .WithMany(p => p.Vehiculo_Proveedores)
                .HasForeignKey(vp => vp.Id_proveedor);

            modelBuilder.Entity<Vehiculo_Proveedor>()
                .HasOne(vp => vp.Conductor)
                .WithMany(c => c.Vehiculo_Proveedores)
                .HasForeignKey(vp => vp.Id_conductor);

            modelBuilder.Entity<Vehiculo_Proveedor>()
                .HasOne(vp => vp.Vehiculo)
                .WithMany(v => v.Vehiculo_Proveedores)
                .HasForeignKey(vp => vp.Id_vehiculo);

            // Configuración de la relación Trabajador_Departamento
            modelBuilder.Entity<Trabajador_Departamento>()
                .HasKey(td => new { td.Id_trabajador, td.Id_departamento });

            modelBuilder.Entity<Trabajador_Departamento>()
                .HasOne(td => td.Trabajador)
                .WithMany(t => t.Trabajador_Departamentos)
                .HasForeignKey(td => td.Id_trabajador);

            modelBuilder.Entity<Trabajador_Departamento>()
                .HasOne(td => td.Departamento)
                .WithMany(d => d.Trabajador_Departamentos)
                .HasForeignKey(td => td.Id_departamento);

            // Configuración de la relación Orden_De_Servicio
            modelBuilder.Entity<Orden_De_Servicio>()
                .HasOne(o => o.Poliza_Cliente)
                .WithMany(pc => pc.Orden_De_Servicios)
                .HasForeignKey(o => new { o.Id_poliza_cliente, o.Id_poliza, o.Id_cliente });

            modelBuilder.Entity<Orden_De_Servicio>()
                .HasOne(o => o.Trabajador)
                .WithMany(t => t.Orden_De_Servicios)
                .HasForeignKey(o => o.Id_trabajador);

            modelBuilder.Entity<Orden_De_Servicio>()
                .HasOne(o => o.Lugar)
                .WithMany(l => l.Orden_De_Servicios)
                .HasForeignKey(o => o.Id_lugar);

            modelBuilder.Entity<Orden_De_Servicio>()
                .HasOne(o => o.Vehiculo_Proveedor)
                .WithMany(vp => vp.Orden_De_Servicios)
                .HasForeignKey(o => new { o.Id_vehiculo_proveedor, o.Id_vehiculo, o.Id_proveedor });

            
            // Configuración de la relación Servicio_Orden
            modelBuilder.Entity<Servicio_Orden>()
                .HasKey(so => new { so.Id_servicio_orden, so.Id_servicio, so.Id_orden_de_servicio });

            modelBuilder.Entity<Servicio_Orden>()
                .HasOne(so => so.Servicio)
                .WithMany(s => s.Servicio_Ordenes)
                .HasForeignKey(so => so.Id_servicio);

            modelBuilder.Entity<Servicio_Orden>()
                .HasOne(so => so.Orden_De_Servicio)
                .WithMany(o => o.Servicio_Ordenes)
                .HasForeignKey(so => so.Id_orden_de_servicio);

            // Configuración de la relación Estado_Orden
            modelBuilder.Entity<Estado_Orden>()
                .HasKey(eo => new { eo.Id_estado_incidente, eo.Id_orden_de_servicio, eo.Id_estado });

            modelBuilder.Entity<Estado_Orden>()
                .HasOne(eo => eo.Orden_De_Servicio)
                .WithMany(o => o.Estado_Ordenes)
                .HasForeignKey(eo => eo.Id_orden_de_servicio);

            modelBuilder.Entity<Estado_Orden>()
                .HasOne(eo => eo.Estado)
                .WithMany(e => e.Estado_Ordenes)
                .HasForeignKey(eo => eo.Id_estado);

         }
    }
}

