namespace API_GruasUCAB.Vehicle.Application.Handlers.GetVehicleByDriverId
{
     public class GetVehicleByDriverIdQueryHandler : IRequestHandler<GetVehicleByDriverIdQuery, GetVehicleByDriverIdResponseDTO>
     {
          private readonly IVehicleRepository _vehicleRepository;

          public GetVehicleByDriverIdQueryHandler(IVehicleRepository vehicleRepository)
          {
               _vehicleRepository = vehicleRepository;
          }

          public async Task<GetVehicleByDriverIdResponseDTO> Handle(GetVehicleByDriverIdQuery request, CancellationToken cancellationToken)
          {
               var vehicle = await _vehicleRepository.GetVehicleByDriverIdAsync(request.DriverId);
               return new GetVehicleByDriverIdResponseDTO { Vehicle = vehicle };
          }
     }
}