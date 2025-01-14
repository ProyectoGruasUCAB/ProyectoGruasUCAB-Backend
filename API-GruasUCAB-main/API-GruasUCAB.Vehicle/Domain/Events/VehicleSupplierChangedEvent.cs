namespace API_GruasUCAB.Vehicle.Domain.Events
{
     public class VehicleSupplierChangedEvent : IDomainEvent
     {
          public VehicleId VehicleId { get; }
          public SupplierId NewSupplierId { get; }
          public DateTime Timestamp { get; }

          public VehicleSupplierChangedEvent(VehicleId vehicleId, SupplierId newSupplierId)
          {
               VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId), "VehicleId cannot be null.");
               NewSupplierId = newSupplierId ?? throw new ArgumentNullException(nameof(newSupplierId), "NewSupplierId cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => VehicleId.ToString();
          public string Name => nameof(VehicleSupplierChangedEvent);
          public object Context => this;
     }
}