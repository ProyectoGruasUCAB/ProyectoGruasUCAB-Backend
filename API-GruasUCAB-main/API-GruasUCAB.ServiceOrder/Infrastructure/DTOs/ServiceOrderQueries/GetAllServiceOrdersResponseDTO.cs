namespace API_GruasUCAB.ServiceOrder.Infrastructure.DTOs.ServiceOrderQueries
{
     public class GetAllServiceOrdersResponseDTO
     {
          [JsonPropertyOrder(2)]
          public List<ServiceOrderDTO> ServiceOrders { get; set; } = new List<ServiceOrderDTO>();
     }
}