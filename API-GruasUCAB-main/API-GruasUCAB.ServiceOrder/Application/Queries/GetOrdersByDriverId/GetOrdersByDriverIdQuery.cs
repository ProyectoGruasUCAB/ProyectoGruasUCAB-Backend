namespace API_GruasUCAB.ServiceOrder.Application.Queries.GetOrdersByDriverId
{
     public class GetOrdersByDriverIdQuery : IRequest<GetOrdersByDriverIdResponseDTO>
     {
          public Guid DriverId { get; set; }

          public GetOrdersByDriverIdQuery(Guid driverId)
          {
               DriverId = driverId;
          }
     }
}