namespace API_GruasUCAB.Department.Infrastructure.DTOs.DepartmentQueries
{
     public class DepartmentDTO
     {
          [JsonPropertyOrder(2)]
          public Guid DepartmentId { get; set; }

          [JsonPropertyOrder(2)]
          public string Name { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string Descripcion { get; set; } = string.Empty;
     }
}