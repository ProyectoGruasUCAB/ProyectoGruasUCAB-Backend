namespace API_GruasUCAB.Vehicle.Domain.Factories
{
     public interface IVehicleTypeFactory
     {
          VehicleType CreateVehicleType(
              VehicleTypeId id,
              VehicleTypeEnumerate type,
              DescripcionVehicleType description);

          Task<VehicleType> GetVehicleTypeById(VehicleTypeId id);
     }
}