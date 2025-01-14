namespace API_GruasUCAB.Vehicle.Application.Queries.GetVehicleById
{
     public class GetVehicleByIdQuery : IRequest<GetVehicleByIdResponseDTO>
     {
          public Guid UserId { get; set; }
          public Guid VehicleId { get; set; }

          public GetVehicleByIdQuery(Guid userId, Guid vehicleId)
          {
               UserId = userId;
               VehicleId = vehicleId;
          }
     }
}