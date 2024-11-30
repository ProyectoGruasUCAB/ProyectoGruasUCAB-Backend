using System.ComponentModel.DataAnnotations;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs
{
     public class AssignRoleRequestDTO
     {
          [Required(ErrorMessage = "User is required.")]
          public string UserId { get; set; } = string.Empty;

          [Required(ErrorMessage = "Rol is required.")]
          public string RoleName { get; set; } = string.Empty;
     }
}