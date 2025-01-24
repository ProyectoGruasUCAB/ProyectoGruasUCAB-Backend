namespace API_GruasUCAB.Department.Infrastructure.DTOs.DepartmentQueries
{
     public class GetDepartmentByNameResponseDTO
     {
          [JsonPropertyOrder(2)]
          public DepartmentDTO? Department { get; set; }
     }
}