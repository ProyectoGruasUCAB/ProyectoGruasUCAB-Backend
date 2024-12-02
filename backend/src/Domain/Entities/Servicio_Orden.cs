
namespace backend.Domain.Entities
{
    public class Servicio_Orden : Base
    {
        public Guid Id_servicio_orden { get; set; }

        public Guid Id_servicio { get; set; }
        public Servicio Servicio { get; set; }

        public Guid Id_orden_de_servicio { get; set; }
        public Orden_De_Servicio Orden_De_Servicio { get; set; }
    }
}
