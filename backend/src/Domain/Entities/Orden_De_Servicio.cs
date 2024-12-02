namespace backend.Domain.Entities
{
    public class Orden_De_Servicio : Base
    {
        public Guid Id_orden_de_servicio { get; set; }
        public string Descrip_incidente { get; set; }
        public string Ubi_inicial_conductor { get; set; }
        public string Ubi_incidente { get; set; }
        public string Ubi_fin_incidente { get; set; }
        public string Distancia_incidente { get; set; }
        public string Descrip_vehiculo_cliente { get; set; }
        public int Costo_incidente { get; set; }

        public Guid Id_poliza_cliente { get; set; }
        public Guid Id_poliza { get; set; }
        public Guid Id_cliente { get; set; }
        public Poliza_Cliente Poliza_Cliente { get; set; }

        public Guid Id_trabajador { get; set; }
        public Trabajador Trabajador { get; set; }

        public Guid Id_lugar { get; set; }
        public Lugar Lugar { get; set; }

        public Guid Id_vehiculo_proveedor { get; set; }
        public Guid Id_vehiculo { get; set; }
        public Guid Id_proveedor { get; set; }
        public Vehiculo_Proveedor Vehiculo_Proveedor { get; set; }
        public ICollection<Servicio_Orden> Servicio_Ordenes { get; set; }
        public ICollection<Estado_Orden> Estado_Ordenes { get; set; }
    }
}
