namespace API_GruasUCAB.Vehicle.Application.Services.UpdateVehicle
{
     public class UpdateVehicleService : IService<UpdateVehicleRequestDTO, UpdateVehicleResponseDTO>
     {
          private readonly IVehicleRepository _vehicleRepository;
          private readonly IVehicleFactory _vehicleFactory;

          public UpdateVehicleService(IVehicleRepository vehicleRepository, IVehicleFactory vehicleFactory)
          {
               _vehicleRepository = vehicleRepository;
               _vehicleFactory = vehicleFactory;
          }

          public async Task<UpdateVehicleResponseDTO> Execute(UpdateVehicleRequestDTO request)
          {
               var vehicleDTO = await _vehicleRepository.GetVehicleByIdAsync(request.VehicleId);
               if (vehicleDTO == null)
               {
                    throw new VehicleNotFoundException(request.VehicleId);
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

               if (request.SupplierId.HasValue)
               {
                    vehicle.ChangeSupplierId(new SupplierId(request.SupplierId.Value));
               }

               vehicleDTO.CivilLiability = vehicle.CivilLiability.Value;
               vehicleDTO.CivilLiabilityExpirationDate = vehicle.CivilLiabilityExpirationDate.Value.ToString("yyyy-MM-dd");
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
          }
     }
}