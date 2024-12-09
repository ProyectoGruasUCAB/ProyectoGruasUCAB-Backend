using API_GruasUCAB.Core.Infrastructure.ResponseDTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs.CreateUser
{
     public class CreateUserRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "Email is required.")]
          [EmailAddress(ErrorMessage = "Invalid email format.")]
          [JsonPropertyOrder(2)]
          public string EmailToCreate { get; set; } = string.Empty;

          [Required(ErrorMessage = "Name role is required.")]
          [JsonPropertyOrder(2)]
          public string NameRole { get; set; } = string.Empty;

          [Required(ErrorMessage = "WorkplaceId is required.")]
          [JsonPropertyOrder(2)]
          public string WorkplaceId { get; set; } = "******************";
     }
}