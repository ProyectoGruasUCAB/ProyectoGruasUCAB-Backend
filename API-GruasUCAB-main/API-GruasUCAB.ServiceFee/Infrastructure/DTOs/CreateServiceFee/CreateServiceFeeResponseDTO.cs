namespace API_GruasUCAB.ServiceFee.Infrastructure.DTOs.CreateServiceFee
{
     public class CreateServiceFeeResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid ServiceFeeId { get; set; }
     }
}