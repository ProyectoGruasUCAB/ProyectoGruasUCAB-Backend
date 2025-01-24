namespace API_GruasUCAB.Vehicle.Application.Services.UpdateVehicleType
{
     public class UpdateVehicleTypeService : IService<UpdateVehicleTypeRequestDTO, UpdateVehicleTypeResponseDTO>
     {
          private readonly IVehicleTypeRepository _vehicleTypeRepository;
          private readonly IVehicleTypeFactory _vehicleTypeFactory;

          public UpdateVehicleTypeService(IVehicleTypeRepository vehicleTypeRepository, IVehicleTypeFactory vehicleTypeFactory)
          {
               _vehicleTypeRepository = vehicleTypeRepository;
               _vehicleTypeFactory = vehicleTypeFactory;
          }

          public async Task<UpdateVehicleTypeResponseDTO> Execute(UpdateVehicleTypeRequestDTO request)
          {
               var vehicleTypeDTO = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(request.VehicleTypeId);
               if (vehicleTypeDTO == null)
               {
                    throw new VehicleTypeNotFoundException(request.VehicleTypeId);
               }

               var vehicleType = _vehicleTypeFactory.CreateVehicleType(
                   new VehicleTypeId(vehicleTypeDTO.VehicleTypeId),
                   Enum.Parse<VehicleTypeEnumerate>(vehicleTypeDTO.Name),
                   new DescripcionVehicleType(vehicleTypeDTO.Description)
               );

               if (!string.IsNullOrEmpty(request.Name))
               {
                    vehicleType.ChangeType(Enum.Parse<VehicleTypeEnumerate>(request.Name));
               }

               if (!string.IsNullOrEmpty(request.Description))
               {
                    vehicleType.ChangeDescripcionVehicleType(new DescripcionVehicleType(request.Description));
               }

               vehicleTypeDTO.Name = vehicleType.Type.ToString();
               vehicleTypeDTO.Description = vehicleType.DescripcionVehicleType.Value;

               await _vehicleTypeRepository.UpdateVehicleTypeAsync(vehicleTypeDTO);

               return new UpdateVehicleTypeResponseDTO
               {
                    Success = true,
                    Message = "Vehicle type updated successfully",
                    VehicleTypeId = vehicleType.Id.Id
               };
          }
     }
}