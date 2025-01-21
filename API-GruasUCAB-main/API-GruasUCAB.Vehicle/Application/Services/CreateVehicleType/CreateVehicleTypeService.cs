namespace API_GruasUCAB.Vehicle.Application.Services.CreateVehicleType
{
     public class CreateVehicleTypeService : IService<CreateVehicleTypeRequestDTO, CreateVehicleTypeResponseDTO>
     {
          private readonly IVehicleTypeRepository _vehicleTypeRepository;
          private readonly IVehicleTypeFactory _vehicleTypeFactory;

          public CreateVehicleTypeService(IVehicleTypeRepository vehicleTypeRepository, IVehicleTypeFactory vehicleTypeFactory)
          {
               _vehicleTypeRepository = vehicleTypeRepository;
               _vehicleTypeFactory = vehicleTypeFactory;
          }

          public async Task<CreateVehicleTypeResponseDTO> Execute(CreateVehicleTypeRequestDTO request)
          {
               var vehicleType = _vehicleTypeFactory.CreateVehicleType(
                   new VehicleTypeId(Guid.NewGuid()),
                   Enum.Parse<VehicleTypeEnumerate>(request.Name),
                   new DescripcionVehicleType(request.Description)
               );

               var vehicleTypeDTO = new VehicleTypeDTO
               {
                    VehicleTypeId = vehicleType.Id.Id,
                    Name = vehicleType.Type.ToString(),
                    Description = vehicleType.DescripcionVehicleType.Value
               };

               await _vehicleTypeRepository.AddVehicleTypeAsync(vehicleTypeDTO);

               return new CreateVehicleTypeResponseDTO
               {
                    Success = true,
                    Message = "Vehicle type created successfully",
                    VehicleTypeId = vehicleType.Id.Id
               };
          }
     }
}