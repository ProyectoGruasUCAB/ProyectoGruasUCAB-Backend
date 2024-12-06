using System.ComponentModel.DataAnnotations;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs.ChangePassword
{
     public class ChangePasswordRequestDTO
     {
          [Required(ErrorMessage = "New Password is required.")]
          public string NewPassword { get; set; } = string.Empty;
     }
}