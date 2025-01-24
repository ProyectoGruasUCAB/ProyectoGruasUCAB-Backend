namespace API_GruasUCAB.Department.Infrastructure.DTOs.UpdateDepartment
{
     public class UpdateDepartmentResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid DepartmentId { get; set; }
     }
}