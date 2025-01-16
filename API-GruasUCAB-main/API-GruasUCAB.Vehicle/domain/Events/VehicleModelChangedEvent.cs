namespace API_GruasUCAB.Vehicle.Domain.Events
{
     public class VehicleModelChangedEvent : IDomainEvent
     {
          public VehicleId VehicleId { get; }
          public VehicleModel NewModel { get; }
          public DateTime Timestamp { get; }

          public VehicleModelChangedEvent(VehicleId vehicleId, VehicleModel newModel)
          {
               VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId), "VehicleId cannot be null.");
               NewModel = newModel ?? throw new ArgumentNullException(nameof(newModel), "NewModel cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => VehicleId.ToString();
          public string Name => nameof(VehicleModelChangedEvent);
          public object Context => this;
     }
}