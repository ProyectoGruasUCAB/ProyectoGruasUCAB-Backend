<<<<<<< HEAD
=======
using API_GruasUCAB.Core.Infrastructure.ResponseDTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

>>>>>>> origin/Development
namespace API_GruasUCAB.Auth.Infrastructure.DTOs.DeleteUser
{
     public class DeleteUserRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "Email is required.")]
          [EmailAddress(ErrorMessage = "Invalid email format.")]
          [JsonPropertyOrder(2)]
          public string EmailToDelete { get; set; } = string.Empty;
     }
}