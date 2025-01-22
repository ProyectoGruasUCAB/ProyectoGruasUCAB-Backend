namespace API_GruasUCAB.Policy.Infrastructure.Adapters.DTOs
{
     public class ClientDTO
     {
          public Guid Id_cliente { get; set; }
          public string Nombre_completo_cliente { get; set; } = string.Empty;
          public int Cedula_cliente { get; set; }
          public int Tlf_cliente { get; set; }
          public DateTime Fecha_nacimiento_cliente { get; set; }
     }
}