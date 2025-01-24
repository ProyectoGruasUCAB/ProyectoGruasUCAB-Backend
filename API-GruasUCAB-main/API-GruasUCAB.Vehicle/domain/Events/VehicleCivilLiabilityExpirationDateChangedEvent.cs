namespace API_GruasUCAB.Vehicle.Domain.Events
{
     public class VehicleCivilLiabilityExpirationDateChangedEvent : IDomainEvent
     {
          public VehicleId VehicleId { get; }
          public VehicleCivilLiabilityExpirationDate NewExpirationDate { get; }
          public DateTime Timestamp { get; }

          public VehicleCivilLiabilityExpirationDateChangedEvent(VehicleId vehicleId, VehicleCivilLiabilityExpirationDate newExpirationDate)
          {
               VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId), "VehicleId cannot be null.");
               NewExpirationDate = newExpirationDate ?? throw new ArgumentNullException(nameof(newExpirationDate), "NewExpirationDate cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => VehicleId.ToString();
          public string Name => nameof(VehicleCivilLiabilityExpirationDateChangedEvent);
          public object Context => this;
     }
}