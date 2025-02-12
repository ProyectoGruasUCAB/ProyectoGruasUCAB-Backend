namespace API_GruasUCAB.Auth.Infrastructure.DTOs.RefreshToken
{
     public class RefreshTokenRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "RefreshToken is required.")]
          [JsonPropertyOrder(2)]
          public string RefreshToken { get; set; } = string.Empty;
     }
}