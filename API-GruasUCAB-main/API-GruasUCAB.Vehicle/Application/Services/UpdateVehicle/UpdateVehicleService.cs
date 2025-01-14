namespace API_GruasUCAB.Vehicle.Application.Services.UpdateVehicle
{
     public class UpdateVehicleService : IService<UpdateVehicleRequestDTO, UpdateVehicleResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly IVehicleFactory _vehicleFactory;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly HeadersToken _headersToken;

          public UpdateVehicleService(IEventStore eventStore, IVehicleFactory vehicleFactory, IKeycloakRepository keycloakRepository, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
          {
               _eventStore = eventStore;
               _vehicleFactory = vehicleFactory;
               _keycloakRepository = keycloakRepository;
               _httpClientFactory = httpClientFactory;
               _headersToken = new HeadersToken(httpContextAccessor);
          }

          public async Task<UpdateVehicleResponseDTO> Execute(UpdateVehicleRequestDTO request)
          {
               var token = _headersToken.GetToken();
               var client = _httpClientFactory.CreateClient();
               var (userId, role, email) = await _keycloakRepository.IntrospectTokenAsync(client, token);

               if (email != request.UserEmail || userId != request.UserId.ToString())
               {
                    throw new UnauthorizedException("Unauthorized access: token validation failed.");
               }

               if (role != "Administrador")
               {
                    throw new UnauthorizedException("Unauthorized access: role validation failed.");
               }

               var vehicle = await _vehicleFactory.GetVehicleById(new VehicleId(request.VehicleId));
               if (vehicle == null)
               {
                    throw new VehicleNotFoundException(request.VehicleId);
               }

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

               if (request.SupplierId.HasValue)
               {
                    vehicle.ChangeSupplierId(new SupplierId(request.SupplierId.Value));
               }

               List<IDomainEvent> domainEvents = new List<IDomainEvent>(vehicle.GetEvents());
               foreach (var domainEvent in vehicle.GetEvents())
               {
                    domainEvents.Add(domainEvent);
               }

               await _eventStore.AppendEvents(vehicle.Id.ToString(), domainEvents);

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
                    DriverId = vehicle.DriverId.Id,
                    SupplierId = vehicle.SupplierId.Id
               };
          }
     }
}