namespace backend.Domain.Entities {
    public class Departamento : Base
    {
        public Guid Id_departamento { get; set; }
        public string Nombre_departamento { get; set; }
        public string Descrip_departamento { get; set; }
        public ICollection<Trabajador_Departamento> Trabajador_Departamentos { get; set; }
 
    }


}