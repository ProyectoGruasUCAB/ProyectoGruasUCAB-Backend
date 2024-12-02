
namespace backend.Domain.Entities
{
    public class Poliza_Cliente : Base
    {
        public Guid Id_poliza_cliente { get; set; }
        public DateTime Fecha_emision_poliza { get; set; }
        public DateTime Fecha_expira_poliza { get; set; }

        public Guid Id_cliente { get; set; }
        public Cliente Cliente { get; set; }

        public Guid Id_poliza { get; set; }
        public Poliza Poliza { get; set; }
        public ICollection<Orden_De_Servicio> Orden_De_Servicios { get; set; }
    }
}
