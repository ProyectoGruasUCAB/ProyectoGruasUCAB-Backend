namespace API_GruasUCAB.Auth.Infrastructure.DTOs.Login
{
     public class LoginResponseDTO : BaseResponseDTO
     {

          [JsonPropertyOrder(2)]
          public string Token { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string RefreshToken { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string UserID { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string Role { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public Guid? WorkerId { get; set; } = Guid.Empty;

          [JsonPropertyOrder(2)]
          public string? WorkerName { get; set; } = string.Empty;

     }
}