using API_GruasUCAB.Core.Infrastructure.ResponseDTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs.Login
{
     public class LoginRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "Password is required.")]
          [JsonPropertyOrder(2)]
          public string Password { get; set; } = string.Empty;
     }
}