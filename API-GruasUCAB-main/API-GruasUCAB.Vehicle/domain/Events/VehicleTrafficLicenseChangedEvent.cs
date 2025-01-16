namespace API_GruasUCAB.Vehicle.Domain.Events
{
     public class VehicleTrafficLicenseChangedEvent : IDomainEvent
     {
          public VehicleId VehicleId { get; }
          public VehicleTrafficLicense NewTrafficLicense { get; }
          public DateTime Timestamp { get; }

          public VehicleTrafficLicenseChangedEvent(VehicleId vehicleId, VehicleTrafficLicense newTrafficLicense)
          {
               VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId), "VehicleId cannot be null.");
               NewTrafficLicense = newTrafficLicense ?? throw new ArgumentNullException(nameof(newTrafficLicense), "NewTrafficLicense cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => VehicleId.ToString();
          public string Name => nameof(VehicleTrafficLicenseChangedEvent);
          public object Context => this;
     }
}