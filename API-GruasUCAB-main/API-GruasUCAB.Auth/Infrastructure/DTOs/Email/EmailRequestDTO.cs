using System.ComponentModel.DataAnnotations;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs.Email
{
     public class EmailRequestDTO
     {
          [Required(ErrorMessage = "ToEmail is required.")]
          public string ToEmail { get; set; } = string.Empty;
          [Required(ErrorMessage = "Subject is required.")]
          public string Subject { get; set; } = string.Empty;
          [Required(ErrorMessage = "Body is required.")]
          public string Body { get; set; } = string.Empty;
     }
}