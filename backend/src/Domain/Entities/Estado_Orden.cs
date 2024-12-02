
namespace backend.Domain.Entities
{
    public class Estado_Orden : Base
    {
        public Guid Id_estado_incidente { get; set; }
        public DateTime Fecha_inicio_incidente { get; set; }
        public DateTime Fecha_fin_incidente { get; set; }

        public Guid Id_orden_de_servicio { get; set; }
        public Orden_De_Servicio Orden_De_Servicio { get; set; }

        public Guid Id_estado { get; set; }
        public Estado Estado { get; set; }
    }
}
