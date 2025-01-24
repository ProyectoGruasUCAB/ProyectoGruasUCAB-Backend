namespace API_GruasUCAB.Vehicle.Domain.Events
{
     public class VehicleDriverChangedEvent : IDomainEvent
     {
          public VehicleId VehicleId { get; }
          public UserId? NewDriverId { get; }
          public DateTime Timestamp { get; }

          public VehicleDriverChangedEvent(VehicleId vehicleId, UserId? newDriverId)
          {
               VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId), "VehicleId cannot be null.");
               NewDriverId = newDriverId;
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => VehicleId.ToString();
          public string Name => nameof(VehicleDriverChangedEvent);
          public object Context => this;
     }
}