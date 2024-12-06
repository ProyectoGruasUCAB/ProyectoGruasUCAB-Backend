using API_GruasUCAB.Core.Infrastructure.ResponseDTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs.Email
{
     public class EmailResponseDTO : BaseResponseDTO
     {
          [Required]
          [JsonPropertyOrder(2)]
          public string Email { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public string Subject { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public string RecipientName { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public string Status { get; set; } = "Sent";
     }
}