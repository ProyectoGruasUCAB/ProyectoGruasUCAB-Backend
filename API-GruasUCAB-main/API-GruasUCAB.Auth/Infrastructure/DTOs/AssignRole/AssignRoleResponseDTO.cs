using API_GruasUCAB.Core.Infrastructure.ResponseDTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs.AssignRole
{
     public class AssignRoleResponseDTO : BaseResponseDTO
     {
          [Required]
          [JsonPropertyOrder(2)]
          public string UserId { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public string RoleName { get; set; } = string.Empty;
     }
}