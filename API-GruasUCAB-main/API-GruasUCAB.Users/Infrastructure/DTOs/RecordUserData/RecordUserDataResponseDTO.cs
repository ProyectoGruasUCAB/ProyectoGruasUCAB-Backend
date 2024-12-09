namespace API_GruasUCAB.Users.Infrastructure.DTOs.RecordUserData
{
     public class RecordUserDataResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }
     }
}