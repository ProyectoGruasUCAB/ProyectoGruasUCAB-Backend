namespace API_GruasUCAB.ServiceOrder.Infrastructure.DTOs.ServiceOrderQueries
{
     public class GetServiceOrderByIdResponseDTO
     {
          [JsonPropertyOrder(2)]
          public ServiceOrderDTO? ServiceOrder { get; set; }
     }
}