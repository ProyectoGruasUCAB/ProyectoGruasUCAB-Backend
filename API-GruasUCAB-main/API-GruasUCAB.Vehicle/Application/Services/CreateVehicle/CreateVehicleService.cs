namespace API_GruasUCAB.Vehicle.Application.Services.CreateVehicle
{
     public class CreateVehicleService : IService<CreateVehicleRequestDTO, CreateVehicleResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly IVehicleFactory _vehicleFactory;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly HeadersToken _headersToken;

          public CreateVehicleService(IEventStore eventStore, IVehicleFactory vehicleFactory, IKeycloakRepository keycloakRepository, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
          {
               _eventStore = eventStore;
               _vehicleFactory = vehicleFactory;
               _keycloakRepository = keycloakRepository;
               _httpClientFactory = httpClientFactory;
               _headersToken = new HeadersToken(httpContextAccessor);
          }

          public async Task<CreateVehicleResponseDTO> Execute(CreateVehicleRequestDTO request)
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

               var vehicle = _vehicleFactory.CreateVehicle(
                   new VehicleId(Guid.NewGuid()),
                   new VehicleCivilLiability(request.CivilLiability),
                   new VehicleCivilLiabilityExpirationDate(request.CivilLiabilityExpirationDate),
                   new VehicleTrafficLicense(request.TrafficLicense),
                   new VehicleLicensePlate(request.LicensePlate),
                   new VehicleBrand(request.Brand),
                   new VehicleColor(request.Color),
                   new VehicleModel(request.Model)
               );

               List<IDomainEvent> domainEvents = new List<IDomainEvent>(vehicle.GetEvents());
               foreach (var domainEvent in vehicle.GetEvents())
               {
                    domainEvents.Add(domainEvent);
               }

               await _eventStore.AppendEvents(vehicle.Id.ToString(), domainEvents);

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