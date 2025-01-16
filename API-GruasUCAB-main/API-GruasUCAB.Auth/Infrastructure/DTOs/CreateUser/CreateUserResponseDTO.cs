namespace API_GruasUCAB.Auth.Infrastructure.DTOs.CreateUser
{
     public class CreateUserResponseDTO : BaseResponseDTO
     {
          [Required]
          [JsonPropertyOrder(2)]
          public string EmailToCreate { get; set; } = string.Empty;
          [Required]
          [JsonPropertyOrder(2)]
          public string NameRole { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public Guid? WorkplaceId { get; set; }
     }
}