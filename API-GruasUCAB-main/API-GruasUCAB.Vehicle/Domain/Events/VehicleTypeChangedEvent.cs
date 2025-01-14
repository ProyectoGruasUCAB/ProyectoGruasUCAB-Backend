namespace API_GruasUCAB.Vehicle.Domain.Events
{
     public class VehicleTypeChangedEvent : IDomainEvent
     {
          public VehicleId VehicleId { get; }
          public VehicleTypeId NewVehicleTypeId { get; }
          public DateTime Timestamp { get; }

          public VehicleTypeChangedEvent(VehicleId vehicleId, VehicleTypeId newVehicleTypeId)
          {
               VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId), "VehicleId cannot be null.");
               NewVehicleTypeId = newVehicleTypeId ?? throw new ArgumentNullException(nameof(newVehicleTypeId), "NewVehicleTypeId cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => VehicleId.ToString();
          public string Name => nameof(VehicleTypeChangedEvent);
          public object Context => this;
     }
}