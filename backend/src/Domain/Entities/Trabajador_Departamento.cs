
namespace backend.Domain.Entities
{
    public class Trabajador_Departamento : Base
    {
        public Guid Id_departamento { get; set; }
        public Departamento Departamento { get; set; }

        public Guid Id_trabajador { get; set; }
        public Trabajador Trabajador { get; set; }
    }
}