namespace API_GruasUCAB.Vehicle.Domain.Factories
{
     public interface IVehicleFactory
     {
          AggregateRoot.Vehicle CreateVehicle(
              VehicleId id,
              VehicleCivilLiability civilLiability,
              VehicleCivilLiabilityExpirationDate civilLiabilityExpirationDate,
              VehicleTrafficLicense trafficLicense,
              VehicleLicensePlate licensePlate,
              VehicleBrand brand,
              VehicleColor color,
              VehicleModel model);

          Task<AggregateRoot.Vehicle> GetVehicleById(VehicleId id);
     }
}