namespace backend.Domain.Entities {
    public class Trabajador : Base
    {
        public Guid Id_trabajador { get; set; }
        public string Nombre_completo_trabajador { get; set; }
        public int Cedula_trabajador { get; set; }
        public int Tlf_trabajador { get; set; }
        public string Cargo_de_trabajo { get; set; }
        public ICollection<Telefono> Telefonos { get; set; }
        public ICollection<Trabajador_Departamento> Trabajador_Departamentos { get; set; }

        public ICollection<Orden_De_Servicio> Orden_De_Servicios { get; set; }
    }


}