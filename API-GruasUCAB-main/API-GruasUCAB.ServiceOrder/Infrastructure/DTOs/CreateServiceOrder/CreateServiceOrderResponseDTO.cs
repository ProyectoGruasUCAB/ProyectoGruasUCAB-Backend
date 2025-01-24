namespace API_GruasUCAB.ServiceOrder.Infrastructure.DTOs.CreateServiceOrder
{
     public class CreateServiceOrderResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid ServiceOrderId { get; set; }

          [JsonPropertyOrder(2)]
          public decimal TotalPrice { get; set; }
     }
}