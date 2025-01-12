namespace API_GruasUCAB.Department.Infrastructure.DTOs.CreateDepartment
{
     public class CreateDepartmentResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid DepartmentId { get; set; }
     }
}