namespace API_GruasUCAB.Vehicle.Application.Handlers.GetVehicleTypeByName
{
     public class GetVehicleTypeByNameQueryHandler : IRequestHandler<GetVehicleTypeByNameQuery, GetVehicleTypeByNameResponseDTO>
     {
          private readonly IVehicleTypeRepository _vehicleTypeRepository;

          public GetVehicleTypeByNameQueryHandler(IVehicleTypeRepository vehicleTypeRepository)
          {
               _vehicleTypeRepository = vehicleTypeRepository;
          }

          public async Task<GetVehicleTypeByNameResponseDTO> Handle(GetVehicleTypeByNameQuery request, CancellationToken cancellationToken)
          {
               var vehicleType = await _vehicleTypeRepository.GetVehicleTypeByNameAsync(request.Name);
               return new GetVehicleTypeByNameResponseDTO { VehicleType = vehicleType };
          }
     }
}