namespace API_GruasUCAB.Department.Infrastructure.DTOs.DepartmentQueries
{
     public class GetAllDepartmentsResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public List<DepartmentDTO> Departments { get; set; } = new List<DepartmentDTO>();
     }
}