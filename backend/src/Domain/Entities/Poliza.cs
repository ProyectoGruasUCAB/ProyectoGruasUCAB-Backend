namespace backend.Domain.Entities {
    public class Poliza : Base
    {
        public Guid Id_poliza { get; set; }
        public int Num_poliza { get; set; }
        public string Nombre_poliza { get; set; }
        public int Monto_cobertura_poliza { get; set; }
        public int Km_cobertura_poliza { get; set; }
        public int Monto_base_poliza { get; set; }
        public int Precio_km_poliza { get; set; }
        public ICollection<Poliza_Cliente> Poliza_Clientes { get; set; }
    }


}