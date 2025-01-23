namespace API_GruasUCAB.ServiceOrder.Infrastructure.DTOs.ServiceOrderQueries
{
     public class GetOrdersByClientIdResponseDTO
     {
          public List<ServiceOrderDTO> ServiceOrders { get; set; } = new List<ServiceOrderDTO>();
     }
}