namespace API_GruasUCAB.Vehicle.Application.Exceptions
{
     public class VehicleTypeNotFoundException : Exception
     {
          public VehicleTypeNotFoundException(Guid vehicleTypeId)
              : base($"Vehicle type with ID {vehicleTypeId} was not found.")
          {
          }
     }
}