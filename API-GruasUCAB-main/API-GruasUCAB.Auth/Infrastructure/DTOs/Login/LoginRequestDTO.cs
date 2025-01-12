namespace API_GruasUCAB.Auth.Infrastructure.DTOs.Login
{
     public class LoginRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "Password is required.")]
          [JsonPropertyOrder(2)]
          public string Password { get; set; } = string.Empty;
     }
}