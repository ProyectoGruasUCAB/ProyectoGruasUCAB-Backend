using backend.Commons.Enums;

namespace backend.Domain.Entities {
    public class Conductor : Base
    {
        public Guid Id_conductor { get; set; }
        public string Nombre_completo_conductor { get; set; }
        public int Tlf_conductor { get; set; }
        public DateTime Fecha_nac_conductor { get; set; }
        public int Cedula_conductor { get; set; }
        public DateTime Fecha_expira_cedula { get; set; }
        public int licencia_conductor { get; set; }
        public TipoLicencia tipoLicencia { get; private set; }
        public DateTime Fecha_expira_licencia { get; set; }
        public int Certificado_medico { get; set; }
        public DateTime Fecha_expira_certificado_medico { get; set; }
        public ICollection<Telefono> Telefonos { get; set; }
        public ICollection<Vehiculo_Proveedor> Vehiculo_Proveedores { get; set; }
    }


}