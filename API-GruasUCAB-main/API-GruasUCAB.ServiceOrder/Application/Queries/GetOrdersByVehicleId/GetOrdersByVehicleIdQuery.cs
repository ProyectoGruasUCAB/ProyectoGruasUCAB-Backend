namespace API_GruasUCAB.ServiceOrder.Application.Queries.GetOrdersByVehicleId
{
     public class GetOrdersByVehicleIdQuery : IRequest<GetOrdersByVehicleIdResponseDTO>
     {
          public Guid VehicleId { get; set; }

          public GetOrdersByVehicleIdQuery(Guid vehicleId)
          {
               VehicleId = vehicleId;
          }
     }
}