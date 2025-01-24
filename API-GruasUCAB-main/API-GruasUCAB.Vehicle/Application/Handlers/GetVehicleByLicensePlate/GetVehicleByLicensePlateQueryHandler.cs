namespace API_GruasUCAB.Vehicle.Application.Handlers.GetVehicleByLicensePlate
{
     public class GetVehicleByLicensePlateQueryHandler : IRequestHandler<GetVehicleByLicensePlateQuery, GetVehicleByLicensePlateResponseDTO>
     {
          private readonly IVehicleRepository _vehicleRepository;

          public GetVehicleByLicensePlateQueryHandler(IVehicleRepository vehicleRepository)
          {
               _vehicleRepository = vehicleRepository;
          }

          public async Task<GetVehicleByLicensePlateResponseDTO> Handle(GetVehicleByLicensePlateQuery request, CancellationToken cancellationToken)
          {
               var vehicle = await _vehicleRepository.GetVehicleByLicensePlateAsync(request.LicensePlate);
               return new GetVehicleByLicensePlateResponseDTO { Vehicle = vehicle };
          }
     }
}