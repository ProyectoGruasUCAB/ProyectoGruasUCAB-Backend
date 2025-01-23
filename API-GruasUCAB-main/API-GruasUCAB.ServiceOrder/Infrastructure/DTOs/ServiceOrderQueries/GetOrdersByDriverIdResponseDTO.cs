namespace API_GruasUCAB.ServiceOrder.Infrastructure.DTOs.ServiceOrderQueries
{
     public class GetOrdersByDriverIdResponseDTO
     {
          public List<ServiceOrderDTO> ServiceOrders { get; set; } = new List<ServiceOrderDTO>();
     }
}