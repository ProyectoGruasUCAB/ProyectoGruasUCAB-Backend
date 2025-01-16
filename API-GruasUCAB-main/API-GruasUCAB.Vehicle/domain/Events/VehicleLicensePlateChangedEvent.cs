namespace API_GruasUCAB.Vehicle.Domain.Events
{
     public class VehicleLicensePlateChangedEvent : IDomainEvent
     {
          public VehicleId VehicleId { get; }
          public VehicleLicensePlate NewLicensePlate { get; }
          public DateTime Timestamp { get; }

          public VehicleLicensePlateChangedEvent(VehicleId vehicleId, VehicleLicensePlate newLicensePlate)
          {
               VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId), "VehicleId cannot be null.");
               NewLicensePlate = newLicensePlate ?? throw new ArgumentNullException(nameof(newLicensePlate), "NewLicensePlate cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => VehicleId.ToString();
          public string Name => nameof(VehicleLicensePlateChangedEvent);
          public object Context => this;
     }
}