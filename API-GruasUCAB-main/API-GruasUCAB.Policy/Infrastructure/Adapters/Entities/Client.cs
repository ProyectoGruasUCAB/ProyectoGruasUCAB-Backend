namespace API_GruasUCAB.Policy.Infrastructure.Adapters.Entities
{
    public class Client
    {
        public Guid Id_cliente { get; set; }
        public string Nombre_completo_cliente { get; set; } = string.Empty;
        public long Cedula_cliente { get; set; }
        public long Tlf_cliente { get; set; }
        public DateTime Fecha_nacimiento_cliente { get; set; }

    }
}