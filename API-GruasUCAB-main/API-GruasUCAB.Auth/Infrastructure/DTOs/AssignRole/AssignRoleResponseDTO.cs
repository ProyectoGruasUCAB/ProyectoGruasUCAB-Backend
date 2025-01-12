namespace API_GruasUCAB.Auth.Infrastructure.DTOs.AssignRole
{
     public class AssignRoleResponseDTO : BaseResponseDTO
     {
          [Required]
          [JsonPropertyOrder(2)]
          public string EmailAssignedRole { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public string RoleName { get; set; } = string.Empty;
     }
}