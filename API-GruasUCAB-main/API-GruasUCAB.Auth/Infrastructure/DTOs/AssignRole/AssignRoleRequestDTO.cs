namespace API_GruasUCAB.Auth.Infrastructure.DTOs.AssignRole
{
     public class AssignRoleRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User is required.")]
          [JsonPropertyOrder(2)]
          public string EmailAssignedRole { get; set; } = string.Empty;

          [Required(ErrorMessage = "Rol is required.")]
          [JsonPropertyOrder(2)]
          public string RoleName { get; set; } = string.Empty;
     }
}