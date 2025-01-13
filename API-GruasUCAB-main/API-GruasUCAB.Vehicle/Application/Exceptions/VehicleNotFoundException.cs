namespace API_GruasUCAB.Vehicle.Application.Exceptions
{
     public class VehicleNotFoundException : Exception
     {
          public VehicleNotFoundException(Guid VehicleId)
              : base($"Vehicle with ID {VehicleId} not found.")
          {
          }
     }
}