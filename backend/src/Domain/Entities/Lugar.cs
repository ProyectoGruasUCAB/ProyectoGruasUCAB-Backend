using backend.Commons.Enums;

namespace backend.Domain.Entities
{
    public class Lugar : Base
    {
        public Guid Id_lugar { get; set; }
        public required string Nombre_lugar { get; set; }
        public TipoLugar TipoLugar { get; private set; }

        public Guid? LugarPadreId { get; set; }
        public Lugar LugarPadre { get; set; }

        public ICollection<Lugar> LugaresHijos { get; set; }
        public ICollection<Orden_De_Servicio> Orden_De_Servicios { get; set; }
    }
}
