namespace API_GruasUCAB.ServiceOrder.Infrastructure.DTOs.CreateServiceOrder
{
     public class CreateServiceOrderResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid ServiceOrderId { get; set; }
     }
}