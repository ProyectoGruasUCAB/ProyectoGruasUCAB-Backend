namespace API_GruasUCAB.Department.Infrastructure.DTOs.CreateDepartment
{
     public class CreateDepartmentRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Name is required.")]
          [JsonPropertyOrder(2)]
          public string Name { get; set; } = string.Empty;

          [Required(ErrorMessage = "Descripcion is required.")]
          [JsonPropertyOrder(2)]
          public string Descripcion { get; set; } = string.Empty;
     }
}