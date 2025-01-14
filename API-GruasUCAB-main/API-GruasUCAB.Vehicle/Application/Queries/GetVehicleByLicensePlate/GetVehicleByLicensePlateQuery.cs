namespace API_GruasUCAB.Vehicle.Application.Queries.GetVehicleByLicensePlate
{
     public class GetVehicleByLicensePlateQuery : IRequest<GetVehicleByLicensePlateResponseDTO>
     {
          public Guid UserId { get; set; }
          public string LicensePlate { get; set; }

          public GetVehicleByLicensePlateQuery(Guid userId, string licensePlate)
          {
               UserId = userId;
               LicensePlate = licensePlate;
          }
     }
}