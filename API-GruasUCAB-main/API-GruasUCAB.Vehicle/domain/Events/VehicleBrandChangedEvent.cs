namespace API_GruasUCAB.Vehicle.Domain.Events
{
     public class VehicleBrandChangedEvent : IDomainEvent
     {
          public VehicleId VehicleId { get; }
          public VehicleBrand NewBrand { get; }
          public DateTime Timestamp { get; }

          public VehicleBrandChangedEvent(VehicleId vehicleId, VehicleBrand newBrand)
          {
               VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId), "VehicleId cannot be null.");
               NewBrand = newBrand ?? throw new ArgumentNullException(nameof(newBrand), "NewBrand cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => VehicleId.ToString();
          public string Name => nameof(VehicleBrandChangedEvent);
          public object Context => this;
     }
}