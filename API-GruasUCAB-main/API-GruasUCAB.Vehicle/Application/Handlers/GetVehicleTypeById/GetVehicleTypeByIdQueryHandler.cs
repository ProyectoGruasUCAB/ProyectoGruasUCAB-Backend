namespace API_GruasUCAB.Vehicle.Application.Handlers.GetVehicleTypeById
{
     public class GetVehicleTypeByIdQueryHandler : IRequestHandler<GetVehicleTypeByIdQuery, GetVehicleTypeByIdResponseDTO>
     {
          private readonly IVehicleTypeRepository _vehicleTypeRepository;

          public GetVehicleTypeByIdQueryHandler(IVehicleTypeRepository vehicleTypeRepository)
          {
               _vehicleTypeRepository = vehicleTypeRepository;
          }

          public async Task<GetVehicleTypeByIdResponseDTO> Handle(GetVehicleTypeByIdQuery request, CancellationToken cancellationToken)
          {
               var vehicleType = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(request.VehicleTypeId);
               return new GetVehicleTypeByIdResponseDTO { VehicleType = vehicleType };
          }
     }
}