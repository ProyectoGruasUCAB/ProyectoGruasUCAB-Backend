namespace API_GruasUCAB.Vehicle.Domain.Events
{
     public class VehicleCivilLiabilityChangedEvent : IDomainEvent
     {
          public VehicleId VehicleId { get; }
          public VehicleCivilLiability NewCivilLiability { get; }
          public DateTime Timestamp { get; }

          public VehicleCivilLiabilityChangedEvent(VehicleId vehicleId, VehicleCivilLiability newCivilLiability)
          {
               VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId), "VehicleId cannot be null.");
               NewCivilLiability = newCivilLiability ?? throw new ArgumentNullException(nameof(newCivilLiability), "NewCivilLiability cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => VehicleId.ToString();
          public string Name => nameof(VehicleCivilLiabilityChangedEvent);
          public object Context => this;
     }
}