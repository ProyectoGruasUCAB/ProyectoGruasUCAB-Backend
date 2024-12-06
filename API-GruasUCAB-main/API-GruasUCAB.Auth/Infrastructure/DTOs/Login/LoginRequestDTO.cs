using System.ComponentModel.DataAnnotations;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs.Login
{
     public class LoginRequestDTO
     {
          [Required(ErrorMessage = "Email is required.")]
          [EmailAddress(ErrorMessage = "Invalid email format.")]
          public string Email { get; set; } = string.Empty;

          [Required(ErrorMessage = "Password is required.")]
          public string Password { get; set; } = string.Empty;
     }
}