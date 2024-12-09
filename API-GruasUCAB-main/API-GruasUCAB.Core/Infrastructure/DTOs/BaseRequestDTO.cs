namespace API_GruasUCAB.Core.Infrastructure.DTOs
{
     public class BaseRequestDTO
     {
          [Required(ErrorMessage = "Email is required.")]
          [EmailAddress(ErrorMessage = "Invalid email format.")]
          [JsonPropertyOrder(1)]
          public string UserEmail { get; set; } = string.Empty;
     }
}