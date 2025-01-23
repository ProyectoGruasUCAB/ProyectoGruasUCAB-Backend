namespace API_GruasUCAB.Vehicle.Application.Handlers.GetVehiclesByDriverIdIsNotNull
{
     public class GetVehiclesByDriverIdIsNotNullQueryHandler : IRequestHandler<GetVehiclesByDriverIdIsNotNullQuery, GetVehiclesByDriverIdIsNotNullResponseDTO>
     {
          private readonly IVehicleRepository _vehicleRepository;

          public GetVehiclesByDriverIdIsNotNullQueryHandler(IVehicleRepository vehicleRepository)
          {
               _vehicleRepository = vehicleRepository;
          }

          public async Task<GetVehiclesByDriverIdIsNotNullResponseDTO> Handle(GetVehiclesByDriverIdIsNotNullQuery request, CancellationToken cancellationToken)
          {
               var vehicles = await _vehicleRepository.GetVehiclesByDriverIdIsNotNullAsync();
               return new GetVehiclesByDriverIdIsNotNullResponseDTO { Vehicles = vehicles };
          }
     }
}