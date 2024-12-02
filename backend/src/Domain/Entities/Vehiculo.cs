namespace backend.Domain.Entities {
    public class Vehiculo : Base
    {
        public Guid Id_vehiculo { get; set; }
        public string Marca_vehiculo { get; set; }
        public string Modelo_vehiculo { get; set; }
        public string Color_vehiculo { get; set; }
        public bool Carnet_circulacion { get; set; }

        public Guid Id_tipo_vehiculo { get; set; }
        public Tipo_Vehiculo Tipo_Vehiculo { get; set; }
        
        public ICollection<Vehiculo_Proveedor> Vehiculo_Proveedores { get; set; }
    }


}