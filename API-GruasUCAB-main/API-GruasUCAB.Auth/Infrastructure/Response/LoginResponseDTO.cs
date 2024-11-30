using System.ComponentModel.DataAnnotations;

namespace API_GruasUCAB.Auth.Infrastructure.Response
{
     public class LoginResponseDTO
     {
          [Required]
          public string Token { get; set; } = string.Empty;

          [Required]
          public string RefreshToken { get; set; } = string.Empty;

          [Required]
          public string UserID { get; set; } = string.Empty;

     }
}