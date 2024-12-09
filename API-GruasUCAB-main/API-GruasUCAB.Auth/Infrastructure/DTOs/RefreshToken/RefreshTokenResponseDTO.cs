using API_GruasUCAB.Core.Infrastructure.ResponseDTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs.RefreshToken
{
     public class RefreshTokenResponseDTO : BaseResponseDTO
     {
          [Required]
          [JsonPropertyOrder(2)]
          public string AccessToken { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public string RefreshToken { get; set; } = string.Empty;
     }
}