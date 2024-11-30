using System.ComponentModel.DataAnnotations;

namespace API_GruasUCAB.Auth.Infrastructure.Response
{
     public class RecoverPasswordResponseDTO
     {
          [Required]
          public bool Success { get; set; }
          [Required]
          public string Message { get; set; } = string.Empty;
     }
}