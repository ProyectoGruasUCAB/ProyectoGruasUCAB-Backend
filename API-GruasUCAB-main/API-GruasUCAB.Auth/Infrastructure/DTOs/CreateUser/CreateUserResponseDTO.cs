using API_GruasUCAB.Core.Infrastructure.ResponseDTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs.CreateUser
{
     public class CreateUserResponseDTO : BaseResponseDTO
     {
          [Required]
          [JsonPropertyOrder(2)]
          public string UserCreatorId { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public string UserId { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public string Email { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public string NameRole { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public string WorkplaceId { get; set; } = string.Empty;
     }
}