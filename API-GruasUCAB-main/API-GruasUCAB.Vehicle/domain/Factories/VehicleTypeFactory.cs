namespace API_GruasUCAB.Vehicle.Domain.Factories
{
     public class VehicleTypeFactory : IVehicleTypeFactory
     {
          private readonly IVehicleTypeRepository _vehicleTypeRepository;

          public VehicleTypeFactory(IVehicleTypeRepository vehicleTypeRepository)
          {
               _vehicleTypeRepository = vehicleTypeRepository;
          }

          public VehicleType CreateVehicleType(
              VehicleTypeId id,
              VehicleTypeEnumerate type,
              DescripcionVehicleType descripcion)
          {
               return new VehicleType(
                   id,
                   type,
                   descripcion
               );
          }

          public async Task<VehicleType> GetVehicleTypeById(VehicleTypeId id)
          {
               var vehicleTypeDTO = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(id.Id);
               return new VehicleType(
                   new VehicleTypeId(vehicleTypeDTO.VehicleTypeId),
                   Enum.Parse<VehicleTypeEnumerate>(vehicleTypeDTO.Name),
                   new DescripcionVehicleType(vehicleTypeDTO.Description)
               );
          }
     }
}