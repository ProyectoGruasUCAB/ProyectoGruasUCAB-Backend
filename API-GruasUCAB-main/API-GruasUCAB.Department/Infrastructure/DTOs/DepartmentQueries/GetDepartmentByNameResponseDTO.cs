namespace API_GruasUCAB.Department.Infrastructure.DTOs.DepartmentQueries
{
     public class GetDepartmentByNameResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public DepartmentDTO? Department { get; set; }
     }
}