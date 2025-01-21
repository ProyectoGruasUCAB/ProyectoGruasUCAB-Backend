namespace API_GruasUCAB.Vehicle.Application.Handlers.GetAllVehicleTypes
{
     public class GetAllVehicleTypesQueryHandler : IRequestHandler<GetAllVehicleTypesQuery, GetAllVehicleTypesResponseDTO>
     {
          private readonly IVehicleTypeRepository _vehicleTypeRepository;

          public GetAllVehicleTypesQueryHandler(IVehicleTypeRepository vehicleTypeRepository)
          {
               _vehicleTypeRepository = vehicleTypeRepository;
          }

          public async Task<GetAllVehicleTypesResponseDTO> Handle(GetAllVehicleTypesQuery request, CancellationToken cancellationToken)
          {
               var vehicleTypes = await _vehicleTypeRepository.GetAllVehicleTypesAsync();
               return new GetAllVehicleTypesResponseDTO { VehicleTypes = vehicleTypes };
          }
     }
}