namespace API_GruasUCAB.Auth.Infrastructure.DTOs.CreateUser
{
     public class CreateUserRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "UserId is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Email is required.")]
          [EmailAddress(ErrorMessage = "Invalid email format.")]
          [JsonPropertyOrder(2)]
          public string EmailToCreate { get; set; } = string.Empty;

          [Required(ErrorMessage = "Name role is required.")]
          [JsonPropertyOrder(2)]
          public string NameRole { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public Guid? WorkplaceId { get; set; }

          [JsonPropertyOrder(2)]
          public string? Position { get; set; } = string.Empty;
     }
}