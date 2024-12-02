namespace backend.Domain.Entities {
    public class Servicio : Base
    {
        public Guid Id_servicio { get; set; }
        public string Nombre_servicio { get; set; }
        public string Descrip_servicio { get; set; }
        public int Costo_servicio { get; set; }
        public ICollection<Servicio_Orden> Servicio_Ordenes { get; set; }

    }
}