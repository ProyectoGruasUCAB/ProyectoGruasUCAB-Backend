namespace API_GruasUCAB.ServiceOrder.Application.Services.CreateServiceOrder
{
     public class CreateServiceOrderService : IService<CreateServiceOrderRequestDTO, CreateServiceOrderResponseDTO>
     {
          private readonly IServiceOrderRepository _serviceOrderRepository;
          private readonly IServiceOrderFactory _serviceOrderFactory;

          public CreateServiceOrderService(IServiceOrderRepository serviceOrderRepository, IServiceOrderFactory serviceOrderFactory)
          {
               _serviceOrderRepository = serviceOrderRepository;
               _serviceOrderFactory = serviceOrderFactory;
          }

          public async Task<CreateServiceOrderResponseDTO> Execute(CreateServiceOrderRequestDTO request)
          {
               TimeZoneInfo venezuelaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Venezuela Standard Time");
               DateTime venezuelaDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, venezuelaTimeZone);

               var serviceOrder = _serviceOrderFactory.CreateServiceOrder(
                   new ServiceOrderId(Guid.NewGuid()),
                   new IncidentDescription(request.IncidentDescription),
                   new Coordinates(request.InitialLocationDriverLat, request.InitialLocationDriverLon),
                   new Coordinates(request.IncidentLocationLat, request.IncidentLocationLon),
                   new Coordinates(request.IncidentLocationEndLat, request.IncidentLocationEndLon),
                   new IncidentDistance(request.IncidentDistance),
                   new CustomerVehicleDescription(request.CustomerVehicleDescription),
                   new IncidentCost(request.IncidentCost),
                   new PolicyId(request.PolicyId),
                   new StatusServiceOrder(ServiceOrderStatus.PorAsignar),
                   new IncidentDate(venezuelaDateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)),
                   new VehicleId(request.VehicleId),
                   new UserId(request.DriverId),
                   new UserId(request.CustomerId),
                   new UserId(request.OperatorId),
                   new ServiceFeeId(request.ServiceFeeId)
               );

               var serviceOrderDTO = new ServiceOrderDTO
               {
                    ServiceOrderId = serviceOrder.Id.Id,
                    StatusServiceOrder = serviceOrder.StatusServiceOrder.Status.ToString(),
                    IncidentDescription = serviceOrder.IncidentDescription.Value,
                    InitialLocationDriverLat = serviceOrder.InitialLocationDriver.Latitude,
                    InitialLocationDriverLon = serviceOrder.InitialLocationDriver.Longitude,
                    IncidentLocationLat = serviceOrder.IncidentLocation.Latitude,
                    IncidentLocationLon = serviceOrder.IncidentLocation.Longitude,
                    IncidentLocationEndLat = serviceOrder.IncidentLocationEnd.Latitude,
                    IncidentLocationEndLon = serviceOrder.IncidentLocationEnd.Longitude,
                    IncidentDistance = serviceOrder.IncidentDistance.Value,
                    CustomerVehicleDescription = serviceOrder.CustomerVehicleDescription.Value,
                    IncidentCost = serviceOrder.IncidentCost.Value,
                    PolicyId = serviceOrder.PolicyId.Id,
                    IncidentDate = serviceOrder.IncidentDate.Value.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    VehicleId = serviceOrder.VehicleId.Id,
                    DriverId = serviceOrder.DriverId.Id,
                    CustomerId = serviceOrder.CustomerId.Id,
                    OperatorId = serviceOrder.OperatorId.Id,
                    ServiceFeeId = serviceOrder.ServiceFeeId.Id
               };

               await _serviceOrderRepository.AddServiceOrderAsync(serviceOrderDTO);

               return new CreateServiceOrderResponseDTO
               {
                    Success = true,
                    Message = $"Service order created successfully: {System.Text.Json.JsonSerializer.Serialize(serviceOrderDTO)}",
                    UserEmail = request.UserEmail,
                    ServiceOrderId = serviceOrder.Id.Id
               };
          }
     }
}