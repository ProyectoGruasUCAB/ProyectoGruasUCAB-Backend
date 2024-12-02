namespace backend.Domain.Entities {
    public class Cliente : Base
    {
        public Guid Id_cliente { get; set; }
        public string Nombre_completo_cliente { get; set; }
        public int Cedula_cliente { get; set; }
        public int Tlf_proveedor { get; set; }
        public ICollection<Telefono> Telefonos { get; set; }
        public ICollection<Poliza_Cliente> Poliza_Clientes { get; set; }
    }


}