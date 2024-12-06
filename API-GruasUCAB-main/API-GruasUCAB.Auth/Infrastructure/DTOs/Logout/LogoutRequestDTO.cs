using System.ComponentModel.DataAnnotations;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs.Logout
{
     public class LogoutRequestDTO
     {
          [Required(ErrorMessage = "RefreshToken is required.")]
          public string RefreshToken { get; set; } = string.Empty;
     }
}