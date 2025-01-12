<<<<<<< HEAD:API-GruasUCAB-main/API-GruasUCAB.Core/Infrastructure/DTOs/BaseRequestDTO.cs
namespace API_GruasUCAB.Core.Infrastructure.DTOs
=======
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs
>>>>>>> origin/Development:API-GruasUCAB-main/API-GruasUCAB.Core/Infrastructure/ResponseDTO/BaseRequestDTO.cs
{
     public class BaseRequestDTO
     {
          [Required(ErrorMessage = "Email is required.")]
          [EmailAddress(ErrorMessage = "Invalid email format.")]
          [JsonPropertyOrder(1)]
          public string UserEmail { get; set; } = string.Empty;
     }
}