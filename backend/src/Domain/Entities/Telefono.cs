
namespace backend.Domain.Entities
{
    public class Telefono : Base
    {
        public Guid Id_tlf { get; set; }
        public string Num_tlf { get; set; }

        public Guid? Id_trabajador { get; set; }
        public Trabajador Trabajador { get; set; }

        public Guid? Id_conductor { get; set; }
        public Conductor Conductor { get; set; }

        public Guid? Id_cliente { get; set; }
        public Cliente Cliente { get; set; }
    }
}
