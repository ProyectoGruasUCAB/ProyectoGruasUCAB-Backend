using System.ComponentModel.DataAnnotations;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs.CreateUser
{
     public class CreateUserRequestDTO
     {
          [Required(ErrorMessage = "Email is required.")]
          [EmailAddress(ErrorMessage = "Invalid email format.")]
          public string Email { get; set; } = string.Empty;
          [Required(ErrorMessage = "Name role is required.")]
          public string NameRole { get; set; } = string.Empty;
          [Required(ErrorMessage = "WorkplaceId is required.")]
          public string WorkplaceId { get; set; } = "******************";
     }
}