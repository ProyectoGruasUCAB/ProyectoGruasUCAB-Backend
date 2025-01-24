namespace API_GruasUCAB.ServiceFee.Infrastructure.DTOs.UpdateServiceFee
{
     public class UpdateServiceFeeResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid ServiceFeeId { get; set; }
     }
}