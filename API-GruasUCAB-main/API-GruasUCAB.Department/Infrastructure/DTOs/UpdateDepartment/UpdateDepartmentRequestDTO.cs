namespace API_GruasUCAB.Department.Infrastructure.DTOs.UpdateDepartment
{
     public class UpdateDepartmentRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Department ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid DepartmentId { get; set; }

          [Required(ErrorMessage = "Name is required.")]
          [JsonPropertyOrder(2)]
          public string? Name { get; set; } = string.Empty;

          [Required(ErrorMessage = "Descripcion is required.")]
          [JsonPropertyOrder(2)]
          public string? Descripcion { get; set; }
     }
}