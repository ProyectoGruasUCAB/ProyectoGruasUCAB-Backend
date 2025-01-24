namespace API_GruasUCAB.Vehicle.Application.Handlers.GetVehiclesBySupplierId
{
     public class GetVehiclesBySupplierIdQueryHandler : IRequestHandler<GetVehiclesBySupplierIdQuery, GetVehiclesBySupplierIdResponseDTO>
     {
          private readonly IVehicleRepository _vehicleRepository;

          public GetVehiclesBySupplierIdQueryHandler(IVehicleRepository vehicleRepository)
          {
               _vehicleRepository = vehicleRepository;
          }

          public async Task<GetVehiclesBySupplierIdResponseDTO> Handle(GetVehiclesBySupplierIdQuery request, CancellationToken cancellationToken)
          {
               var vehicles = await _vehicleRepository.GetVehiclesBySupplierIdAsync(request.SupplierId);
               return new GetVehiclesBySupplierIdResponseDTO { Vehicles = vehicles };
          }
     }
}