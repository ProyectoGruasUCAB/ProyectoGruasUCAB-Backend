namespace API_GruasUCAB.Vehicle.Application.Services.CreateVehicle
{
     public class CreateVehicleService : IService<CreateVehicleRequestDTO, CreateVehicleResponseDTO>
     {
          private readonly IVehicleRepository _vehicleRepository;
          private readonly IVehicleTypeRepository _vehicleTypeRepository;
          private readonly IVehicleFactory _vehicleFactory;

          public CreateVehicleService(IVehicleRepository vehicleRepository, IVehicleTypeRepository vehicleTypeRepository, IVehicleFactory vehicleFactory)
          {
               _vehicleRepository = vehicleRepository;
               _vehicleTypeRepository = vehicleTypeRepository;
               _vehicleFactory = vehicleFactory;
          }

          public async Task<CreateVehicleResponseDTO> Execute(CreateVehicleRequestDTO request)
          {
               var vehicleType = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(request.VehicleTypeId);
               if (vehicleType == null)
               {
                    throw new KeyNotFoundException($"VehicleType with ID {request.VehicleTypeId} not found.");
               }

               var vehicle = _vehicleFactory.CreateVehicle(
                   new VehicleId(Guid.NewGuid()),
                   new VehicleCivilLiability(request.CivilLiability),
                   new VehicleCivilLiabilityExpirationDate(request.CivilLiabilityExpirationDate),
                   new VehicleTrafficLicense(request.TrafficLicense),
                   new VehicleLicensePlate(request.LicensePlate),
                   new VehicleBrand(request.Brand),
                   new VehicleColor(request.Color),
                   new VehicleModel(request.Model),
                   new VehicleTypeId(request.VehicleTypeId),
                   request.DriverId.HasValue ? new UserId(request.DriverId.Value) : (UserId?)null,
                   new SupplierId(request.SupplierId)
               );

               var vehicleDTO = new VehicleDTO
               {
                    VehicleId = vehicle.Id.Id,
                    CivilLiability = vehicle.CivilLiability.Value,
                    CivilLiabilityExpirationDate = vehicle.CivilLiabilityExpirationDate.Value.ToString("dd-MM-yyyy"),
                    TrafficLicense = vehicle.TrafficLicense.Value,
                    LicensePlate = vehicle.LicensePlate.Value,
                    Brand = vehicle.Brand.Value,
                    Color = vehicle.Color.Value,
                    Model = vehicle.Model.Value,
                    VehicleTypeId = vehicle.VehicleTypeId.Id,
                    DriverId = vehicle.DriverId?.Id,
                    SupplierId = vehicle.SupplierId.Id
               };

               await _vehicleRepository.AddVehicleAsync(vehicleDTO);

               return new CreateVehicleResponseDTO
               {
                    Success = true,
                    Message = "Vehicle created successfully",
                    UserEmail = request.UserEmail,
                    VehicleId = vehicle.Id.Id
               };
          }
     }
}