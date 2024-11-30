using System.ComponentModel.DataAnnotations;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs
{
     public class RecoverPasswordRequestDTO
     {
          [Required(ErrorMessage = "Email is required.")]
          [EmailAddress(ErrorMessage = "Invalid email format.")]
          public string Email { get; set; } = string.Empty;
     }
}