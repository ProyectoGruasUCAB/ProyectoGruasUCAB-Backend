namespace API_GruasUCAB.Vehicle.Application.Services.UpdateVehicle
{
     public class UpdateVehicleService : IService<UpdateVehicleRequestDTO, UpdateVehicleResponseDTO>
     {
          private readonly IVehicleRepository _vehicleRepository;
          private readonly IVehicleTypeRepository _vehicleTypeRepository;
          private readonly IVehicleFactory _vehicleFactory;
          private readonly IProviderRepository _providerRepository;
          private readonly IDriverRepository _driverRepository;

          public UpdateVehicleService(IVehicleRepository vehicleRepository, IVehicleTypeRepository vehicleTypeRepository, IVehicleFactory vehicleFactory, IProviderRepository providerRepository, IDriverRepository driverRepository)
          {
               _vehicleRepository = vehicleRepository;
               _vehicleTypeRepository = vehicleTypeRepository;
               _vehicleFactory = vehicleFactory;
               _providerRepository = providerRepository;
               _driverRepository = driverRepository;
          }

          public async Task<UpdateVehicleResponseDTO> Execute(UpdateVehicleRequestDTO request)
          {
               var vehicleDTO = await _vehicleRepository.GetVehicleByIdAsync(request.VehicleId);
               var provider = await _providerRepository.GetProviderByIdAsync(request.UserId);
               if (provider.SupplierId != vehicleDTO.SupplierId)
               {
                    throw new UnauthorizedAccessException("User does not have permission to update this vehicle.");
               }
               if (request.DriverId.HasValue)
               {
                    var driver = await _driverRepository.GetDriverByIdAsync(request.DriverId.Value);
                    if (driver.SupplierId != vehicleDTO.SupplierId || driver.SupplierId != provider.SupplierId)
                    {
                         throw new UnauthorizedAccessException("Driver does not have permission to be assigned to this vehicle.");
                    }
               }
               if (request.VehicleTypeId.HasValue)
               {
                    var vehicleType = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(request.VehicleTypeId.Value);
                    if (vehicleType == null)
                    {
                         throw new KeyNotFoundException($"VehicleType with ID {request.VehicleTypeId.Value} not found.");
                    }
               }

               var vehicle = _vehicleFactory.CreateVehicle(
                   new VehicleId(vehicleDTO.VehicleId),
                   new VehicleCivilLiability(vehicleDTO.CivilLiability),
                   new VehicleCivilLiabilityExpirationDate(vehicleDTO.CivilLiabilityExpirationDate),
                   new VehicleTrafficLicense(vehicleDTO.TrafficLicense),
                   new VehicleLicensePlate(vehicleDTO.LicensePlate),
                   new VehicleBrand(vehicleDTO.Brand),
                   new VehicleColor(vehicleDTO.Color),
                   new VehicleModel(vehicleDTO.Model),
                   new VehicleTypeId(vehicleDTO.VehicleTypeId),
                   vehicleDTO.DriverId.HasValue ? new UserId(vehicleDTO.DriverId.Value) : (UserId?)null,
                   new SupplierId(vehicleDTO.SupplierId)
               );

               if (!string.IsNullOrEmpty(request.CivilLiability))
               {
                    vehicle.ChangeCivilLiability(new VehicleCivilLiability(request.CivilLiability));
               }

               if (!string.IsNullOrEmpty(request.CivilLiabilityExpirationDate))
               {
                    vehicle.ChangeCivilLiabilityExpirationDate(new VehicleCivilLiabilityExpirationDate(request.CivilLiabilityExpirationDate));
               }

               if (!string.IsNullOrEmpty(request.TrafficLicense))
               {
                    vehicle.ChangeTrafficLicense(new VehicleTrafficLicense(request.TrafficLicense));
               }

               if (!string.IsNullOrEmpty(request.LicensePlate))
               {
                    vehicle.ChangeLicensePlate(new VehicleLicensePlate(request.LicensePlate));
               }

               if (!string.IsNullOrEmpty(request.Brand))
               {
                    vehicle.ChangeBrand(new VehicleBrand(request.Brand));
               }

               if (!string.IsNullOrEmpty(request.Color))
               {
                    vehicle.ChangeColor(new VehicleColor(request.Color));
               }

               if (!string.IsNullOrEmpty(request.Model))
               {
                    vehicle.ChangeModel(new VehicleModel(request.Model));
               }

               if (request.VehicleTypeId.HasValue)
               {
                    vehicle.ChangeVehicleTypeId(new VehicleTypeId(request.VehicleTypeId.Value));
               }

               if (request.DriverId.HasValue)
               {
                    vehicle.ChangeDriverId(new UserId(request.DriverId.Value));
               }
               else
               {
                    vehicle.ChangeDriverId(null);
               }

               vehicleDTO.CivilLiability = vehicle.CivilLiability.Value;
               vehicleDTO.CivilLiabilityExpirationDate = vehicle.CivilLiabilityExpirationDate.Value.ToString("dd-MM-yyyy");
               vehicleDTO.TrafficLicense = vehicle.TrafficLicense.Value;
               vehicleDTO.LicensePlate = vehicle.LicensePlate.Value;
               vehicleDTO.Brand = vehicle.Brand.Value;
               vehicleDTO.Color = vehicle.Color.Value;
               vehicleDTO.Model = vehicle.Model.Value;
               vehicleDTO.VehicleTypeId = vehicle.VehicleTypeId.Id;
               vehicleDTO.DriverId = vehicle.DriverId?.Id;
               vehicleDTO.SupplierId = vehicle.SupplierId.Id;

               await _vehicleRepository.UpdateVehicleAsync(vehicleDTO);

               return new UpdateVehicleResponseDTO
               {
                    Success = true,
                    Message = "Vehicle updated successfully",
                    UserEmail = request.UserEmail,
                    VehicleId = vehicle.Id.Id
               };
          }
     }
}