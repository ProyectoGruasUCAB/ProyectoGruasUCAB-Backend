using API_GruasUCAB.Core.Infrastructure.ResponseDTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs.Login
{
     public class LoginResponseDTO : BaseResponseDTO
     {
          [Required]
          [JsonPropertyOrder(2)]
          public string Token { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public string RefreshToken { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public string UserID { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public string Role { get; set; } = string.Empty;
     }
}