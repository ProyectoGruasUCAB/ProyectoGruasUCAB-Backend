namespace API_GruasUCAB.ServiceOrder.Infrastructure.DTOs.ServiceOrderQueries
{
     public class GetServiceOrdersByStatusResponseDTO
     {
          [JsonPropertyOrder(2)]
          public List<ServiceOrderDTO> ServiceOrders { get; set; } = new List<ServiceOrderDTO>();

          [JsonPropertyOrder(1)]
          public string Status { get; set; } = string.Empty;
     }
}