namespace API_GruasUCAB.Vehicle.Application.Queries.GetVehicleByDriverId
{
     public class GetVehicleByDriverIdQuery : IRequest<GetVehicleByDriverIdResponseDTO>
     {
          public Guid DriverId { get; set; }

          public GetVehicleByDriverIdQuery(Guid driverId)
          {
               DriverId = driverId;
          }
     }
}