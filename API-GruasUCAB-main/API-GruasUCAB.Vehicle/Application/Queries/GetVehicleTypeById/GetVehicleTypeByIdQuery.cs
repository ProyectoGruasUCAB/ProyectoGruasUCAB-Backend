namespace API_GruasUCAB.Vehicle.Application.Queries.GetVehicleTypeById
{
     public class GetVehicleTypeByIdQuery : IRequest<GetVehicleTypeByIdResponseDTO>
     {
          public Guid VehicleTypeId { get; set; }

          public GetVehicleTypeByIdQuery(Guid vehicleTypeId)
          {
               VehicleTypeId = vehicleTypeId;
          }
     }
}