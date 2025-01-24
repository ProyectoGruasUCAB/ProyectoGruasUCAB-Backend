namespace API_GruasUCAB.Auth.Infrastructure.DTOs.Logout
{
     public class LogoutRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "RefreshToken is required.")]
          [JsonPropertyOrder(2)]
          public string RefreshToken { get; set; } = string.Empty;
     }
}