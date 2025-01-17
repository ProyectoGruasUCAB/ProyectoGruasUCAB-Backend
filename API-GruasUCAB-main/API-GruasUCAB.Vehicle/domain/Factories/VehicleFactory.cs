namespace API_GruasUCAB.Vehicle.Domain.Factories
{
     public class VehicleFactory : IVehicleFactory
     {
          private readonly IVehicleRepository _vehicleRepository;

          public VehicleFactory(IVehicleRepository vehicleRepository)
          {
               _vehicleRepository = vehicleRepository;
          }

          public AggregateRoot.Vehicle CreateVehicle(
              VehicleId id,
              VehicleCivilLiability civilLiability,
              VehicleCivilLiabilityExpirationDate civilLiabilityExpirationDate,
              VehicleTrafficLicense trafficLicense,
              VehicleLicensePlate licensePlate,
              VehicleBrand brand,
              VehicleColor color,
              VehicleModel model,
              VehicleTypeId vehicleTypeId,
              UserId driverId,
              SupplierId supplierId)
          {
               return new AggregateRoot.Vehicle(
                   id,
                   civilLiability,
                   civilLiabilityExpirationDate,
                   trafficLicense,
                   licensePlate,
                   brand,
                   color,
                   model,
                   vehicleTypeId,
                   driverId,
                   supplierId
               );
          }

          public async Task<AggregateRoot.Vehicle> GetVehicleById(VehicleId id)
          {
               var vehicleDTO = await _vehicleRepository.GetVehicleByIdAsync(id.Id);
               return new AggregateRoot.Vehicle(
                   new VehicleId(vehicleDTO.VehicleId),
                   new VehicleCivilLiability(vehicleDTO.CivilLiability),
                   new VehicleCivilLiabilityExpirationDate(vehicleDTO.CivilLiabilityExpirationDate),
                   new VehicleTrafficLicense(vehicleDTO.TrafficLicense),
                   new VehicleLicensePlate(vehicleDTO.LicensePlate),
                   new VehicleBrand(vehicleDTO.Brand),
                   new VehicleColor(vehicleDTO.Color),
                   new VehicleModel(vehicleDTO.Model),
                   new VehicleTypeId(vehicleDTO.VehicleTypeId),
                   new UserId(vehicleDTO.DriverId),
                   new SupplierId(vehicleDTO.SupplierId)
               );
          }
     }
}