namespace API_GruasUCAB.Users.Infrastructure.DTOs.UpdateUser
{
     public class UpdateRecordUserDataResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }
     }
}