namespace API_GruasUCAB.Vehicle.Application.Handlers.GetAllVehicles
{
     public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, GetAllVehiclesResponseDTO>
     {
          private readonly IVehicleRepository _vehicleRepository;

          public GetAllVehiclesQueryHandler(IVehicleRepository vehicleRepository)
          {
               _vehicleRepository = vehicleRepository;
          }

          public async Task<GetAllVehiclesResponseDTO> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
          {
               var vehicles = await _vehicleRepository.GetAllVehiclesAsync();
               return new GetAllVehiclesResponseDTO { Vehicles = vehicles };
          }
     }
}