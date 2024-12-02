namespace backend.Domain.Entities {
    public class Tipo_Vehiculo : Base
    {
        public Guid Id_tipo_vehiculo { get; set; }
        public string Nombre_tipo_vehiculo { get; set; }
        public string Descrip_tipo_vehiculo { get; set; }
        public ICollection<Vehiculo> Vehiculos { get; set; }

    }


}