namespace API_GruasUCAB.Vehicle.Application.Handlers.GetVehicleById
{
     public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, GetVehicleByIdResponseDTO>
     {
          private readonly IVehicleRepository _vehicleRepository;

          public GetVehicleByIdQueryHandler(IVehicleRepository vehicleRepository)
          {
               _vehicleRepository = vehicleRepository;
          }

          public async Task<GetVehicleByIdResponseDTO> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
          {
               var vehicle = await _vehicleRepository.GetVehicleByIdAsync(request.VehicleId);
               return new GetVehicleByIdResponseDTO { Vehicle = vehicle };
          }
     }
}