namespace API_GruasUCAB.Vehicle.Domain.Events
{
     public class VehicleCreatedEvent : IDomainEvent
     {
          public VehicleId VehicleId { get; }
          public VehicleCivilLiability VehicleCivilLiability { get; }
          public VehicleCivilLiabilityExpirationDate VehicleCivilLiabilityExpirationDate { get; }
          public VehicleTrafficLicense VehicleTrafficLicense { get; }
          public VehicleLicensePlate VehicleLicensePlate { get; }
          public VehicleBrand VehicleBrand { get; }
          public VehicleColor VehicleColor { get; }
          public VehicleModel VehicleModel { get; }
          public VehicleTypeId VehicleTypeId { get; }
          public UserId? UserId { get; }
          public SupplierId SupplierId { get; }
          public DateTime Timestamp { get; }

          public VehicleCreatedEvent(
              VehicleId vehicleId,
              VehicleCivilLiability vehicleCivilLiability,
              VehicleCivilLiabilityExpirationDate vehicleCivilLiabilityExpirationDate,
              VehicleTrafficLicense vehicleTrafficLicense,
              VehicleLicensePlate vehicleLicensePlate,
              VehicleBrand vehicleBrand,
              VehicleColor vehicleColor,
              VehicleModel vehicleModel,
              VehicleTypeId vehicleTypeId,
              UserId? userId,
              SupplierId supplierId)
          {
               VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId), "VehicleId cannot be null.");
               VehicleCivilLiability = vehicleCivilLiability ?? throw new ArgumentNullException(nameof(vehicleCivilLiability), "VehicleCivilLiability cannot be null.");
               VehicleCivilLiabilityExpirationDate = vehicleCivilLiabilityExpirationDate ?? throw new ArgumentNullException(nameof(vehicleCivilLiabilityExpirationDate), "VehicleCivilLiabilityExpirationDate cannot be null.");
               VehicleTrafficLicense = vehicleTrafficLicense ?? throw new ArgumentNullException(nameof(vehicleTrafficLicense), "VehicleTrafficLicense cannot be null.");
               VehicleLicensePlate = vehicleLicensePlate ?? throw new ArgumentNullException(nameof(vehicleLicensePlate), "VehicleLicensePlate cannot be null.");
               VehicleBrand = vehicleBrand ?? throw new ArgumentNullException(nameof(vehicleBrand), "VehicleBrand cannot be null.");
               VehicleColor = vehicleColor ?? throw new ArgumentNullException(nameof(vehicleColor), "VehicleColor cannot be null.");
               VehicleModel = vehicleModel ?? throw new ArgumentNullException(nameof(vehicleModel), "VehicleModel cannot be null.");
               VehicleTypeId = vehicleTypeId ?? throw new ArgumentNullException(nameof(vehicleTypeId), "VehicleTypeId cannot be null.");
               UserId = userId;
               SupplierId = supplierId ?? throw new ArgumentNullException(nameof(supplierId), "SupplierId cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => VehicleId.ToString();
          public string Name => nameof(VehicleCreatedEvent);
          public object Context => this;
     }
}