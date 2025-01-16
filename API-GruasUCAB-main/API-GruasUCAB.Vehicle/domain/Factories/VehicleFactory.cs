namespace API_GruasUCAB.Vehicle.Domain.Factories
{
     public class VehicleFactory : IVehicleFactory
     {
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
               // Implementación para obtener un vehículo por su ID
               // Esto puede incluir una llamada a una base de datos o un servicio externo
               // Por ahora, lanzamos una excepción para indicar que no está implementado
               // throw new NotImplementedException();

               // Ejemplo de implementación simulada
               await Task.CompletedTask; // Simula una operación asincrónica
               return new AggregateRoot.Vehicle(
                   id,
                   new VehicleCivilLiability("Full Coverage"),
                   new VehicleCivilLiabilityExpirationDate("31-12-2025"),
                   new VehicleTrafficLicense("A123456789"),
                   new VehicleLicensePlate("ABC1234"),
                   new VehicleBrand("Toyota"),
                   new VehicleColor("Red"),
                   new VehicleModel("Corolla"),
                   new VehicleTypeId(Guid.NewGuid()),
                   new UserId(Guid.NewGuid()),
                   new SupplierId(Guid.NewGuid())
               );
          }
     }
}