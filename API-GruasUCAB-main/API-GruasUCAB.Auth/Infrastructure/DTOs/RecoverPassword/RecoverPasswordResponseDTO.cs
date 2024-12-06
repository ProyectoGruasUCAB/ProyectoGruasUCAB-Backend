using API_GruasUCAB.Core.Infrastructure.ResponseDTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs.RecoverPassword
{
     public class RecoverPasswordResponseDTO : BaseResponseDTO
     {
          [Required]
          [JsonPropertyOrder(2)]
          public string Email { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public bool TemporaryPassword { get; set; }
     }
}