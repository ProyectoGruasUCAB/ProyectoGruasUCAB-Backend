<<<<<<< HEAD
=======
using API_GruasUCAB.Core.Infrastructure.ResponseDTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

>>>>>>> origin/Development
namespace API_GruasUCAB.Auth.Infrastructure.DTOs.ChangePassword
{
     public class ChangePasswordRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "New Password is required.")]
          [JsonPropertyOrder(2)]
          public string NewPassword { get; set; } = string.Empty;
     }
}