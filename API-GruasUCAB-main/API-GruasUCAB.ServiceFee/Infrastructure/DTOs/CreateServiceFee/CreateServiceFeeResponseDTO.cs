namespace API_GruasUCAB.ServiceFee.Infrastructure.DTOs.UpdateServiceFee
{
     public class CreateServiceFeeResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid ServiceFeeId { get; set; }
     }
}