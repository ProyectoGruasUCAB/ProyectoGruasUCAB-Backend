namespace API_GruasUCAB.Vehicle.Domain.Events
{
     public class VehicleColorChangedEvent : IDomainEvent
     {
          public VehicleId VehicleId { get; }
          public VehicleColor NewColor { get; }
          public DateTime Timestamp { get; }

          public VehicleColorChangedEvent(VehicleId vehicleId, VehicleColor newColor)
          {
               VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId), "VehicleId cannot be null.");
               NewColor = newColor ?? throw new ArgumentNullException(nameof(newColor), "NewColor cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => VehicleId.ToString();
          public string Name => nameof(VehicleColorChangedEvent);
          public object Context => this;
     }
}