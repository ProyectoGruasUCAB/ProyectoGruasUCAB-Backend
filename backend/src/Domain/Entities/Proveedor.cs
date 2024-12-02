namespace backend.Domain.Entities {
    public class Proveedor : Base
    {
        public Guid Id_proveedor { get; set; }
        public string Nombre_proveedor { get; set; }
        public string Denom_comercial_proveedor { get; set; }
        public int Rif_proveedor { get; set; }
        public ICollection<Vehiculo_Proveedor> Vehiculo_Proveedores { get; set; }
    }


}