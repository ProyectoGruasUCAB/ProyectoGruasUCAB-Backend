namespace API_GruasUCAB.Auth.Infrastructure.DTOs.DeleteUser
{
     public class DeleteUserResponseDTO : BaseResponseDTO
     {
          [Required]
          [JsonPropertyOrder(2)]
          public string DeletedUserEmail { get; set; } = string.Empty;
     }
}