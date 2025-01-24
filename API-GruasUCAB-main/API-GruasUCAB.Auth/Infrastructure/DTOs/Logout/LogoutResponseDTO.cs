namespace API_GruasUCAB.Auth.Infrastructure.DTOs.Logout
{
     public class LogoutResponseDTO : BaseResponseDTO
     {
          [Required]
          [JsonPropertyOrder(2)]
          public bool Active { get; set; }
     }
}