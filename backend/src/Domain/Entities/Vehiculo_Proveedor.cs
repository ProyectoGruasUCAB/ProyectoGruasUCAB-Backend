
namespace backend.Domain.Entities
{
    public class Vehiculo_Proveedor : Base
    {
        public Guid Id_vehiculo_proveedor { get; set; }
        public bool Respon_civil { get; set; }
        public DateTime Fecha_expira_respon_civil { get; set; }

        public Guid Id_proveedor { get; set; }
        public Proveedor Proveedor { get; set; }

        public Guid Id_conductor { get; set; }
        public Conductor Conductor { get; set; }

        public Guid Id_vehiculo { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public ICollection<Orden_De_Servicio> Orden_De_Servicios { get; set; }
    }
}
