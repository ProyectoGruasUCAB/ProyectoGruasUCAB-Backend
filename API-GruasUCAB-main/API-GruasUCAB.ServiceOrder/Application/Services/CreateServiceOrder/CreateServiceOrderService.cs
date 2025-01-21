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
               if (request.InitialStatus != ServiceOrderStatus.PorAsignar.ToString() && request.InitialStatus != ServiceOrderStatus.PorAceptado.ToString())
               {
                    throw new ArgumentException($"Invalid initial status: {request.InitialStatus}. Allowed statuses are: {ServiceOrderStatus.PorAsignar}, {ServiceOrderStatus.PorAceptado}");
               }

               TimeZoneInfo venezuelaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Venezuela Standard Time");
               DateTime venezuelaDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, venezuelaTimeZone);

               var serviceOrder = _serviceOrderFactory.CreateServiceOrder(
                   new ServiceOrderId(Guid.NewGuid()),
                   new IncidentDescription(request.IncidentDescription),
                   new Coordinates((float)request.InitialLocationDriverLatitude, (float)request.InitialLocationDriverLongitude),
                   new Coordinates((float)request.IncidentLocationLatitude, (float)request.IncidentLocationLongitude),
                   new Coordinates((float)request.IncidentLocationEndLatitude, (float)request.IncidentLocationEndLongitude),
                   new IncidentDistance(request.IncidentDistance),
                   new CustomerVehicleDescription(request.CustomerVehicleDescription),
                   new IncidentCost(request.IncidentCost),
                   new PolicyId(request.PolicyId),
                   new StatusServiceOrder(Enum.Parse<ServiceOrderStatus>(request.InitialStatus)),
                   new IncidentDate(venezuelaDateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)),
                   new VehicleId(request.VehicleId),
                   new UserId(request.DriverId),
                   new UserId(request.CustomerId),
                   new UserId(request.OperatorId),
                   new ServiceFeeId(request.ServiceFeeId)
               );

               var serviceOrderDTO = new ServiceOrderDTO
               {
                    ServiceOrderId = serviceOrder.Id.Value,
                    StatusServiceOrder = serviceOrder.StatusServiceOrder.Value.ToString(),
                    IncidentDescription = serviceOrder.IncidentDescription.Value,
                    InitialLocationDriverLatitude = (float)serviceOrder.InitialLocationDriver.Latitude,
                    InitialLocationDriverLongitude = (float)serviceOrder.InitialLocationDriver.Longitude,
                    IncidentLocationLatitude = (float)serviceOrder.IncidentLocation.Latitude,
                    IncidentLocationLongitude = (float)serviceOrder.IncidentLocation.Longitude,
                    IncidentLocationEndLatitude = (float)serviceOrder.IncidentLocationEnd.Latitude,
                    IncidentLocationEndLongitude = (float)serviceOrder.IncidentLocationEnd.Longitude,
                    IncidentDistance = (float)serviceOrder.IncidentDistance.Value,
                    CustomerVehicleDescription = serviceOrder.CustomerVehicleDescription.Value,
                    IncidentCost = (float)serviceOrder.IncidentCost.Value,
                    PolicyId = serviceOrder.PolicyId.Value,
                    IncidentDate = serviceOrder.IncidentDate.Value.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    VehicleId = serviceOrder.VehicleId.Value,
                    DriverId = serviceOrder.DriverId.Value,
                    CustomerId = serviceOrder.CustomerId.Value,
                    OperatorId = serviceOrder.OperatorId.Value,
                    ServiceFeeId = serviceOrder.ServiceFeeId.Value
               };

               await _serviceOrderRepository.AddServiceOrderAsync(serviceOrderDTO);

               return new CreateServiceOrderResponseDTO
               {
                    Success = true,
                    Message = $"Service order created successfully: {System.Text.Json.JsonSerializer.Serialize(serviceOrderDTO)}",
                    UserEmail = request.UserEmail,
                    ServiceOrderId = serviceOrder.Id.Value
               };
          }
     }
}