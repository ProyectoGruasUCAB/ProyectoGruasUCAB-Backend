namespace API_GruasUCAB.Vehicle.Application.Services.CreateVehicle
{
     public class CreateVehicleService : IService<CreateVehicleRequestDTO, CreateVehicleResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly IVehicleFactory _vehicleFactory;

          public CreateVehicleService(IEventStore eventStore, IVehicleFactory vehicleFactory)
          {
               _eventStore = eventStore;
               _vehicleFactory = vehicleFactory;
          }

          public async Task<CreateVehicleResponseDTO> Execute(CreateVehicleRequestDTO request)
          {
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
                   new UserId(request.DriverId),
                   new SupplierId(request.SupplierId)
               );

               var domainEvents = new List<IDomainEvent>(vehicle.GetEvents());

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