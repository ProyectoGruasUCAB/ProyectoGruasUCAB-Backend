namespace API_GruasUCAB.Auth.Infrastructure.DTOs.HandleIncompleteAccount
{
     public class IncompleteAccountRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "Password is required.")]
          [JsonPropertyOrder(2)]
          public string Password { get; set; } = string.Empty;

          [Required(ErrorMessage = "New Password is required.")]
          [JsonPropertyOrder(2)]
          public string NewPassword { get; set; } = string.Empty;
     }
}