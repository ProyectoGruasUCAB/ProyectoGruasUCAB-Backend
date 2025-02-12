namespace API_GruasUCAB.ServiceOrder.Application.Services.CreateServiceOrder
{
     public class CreateServiceOrderService : IService<CreateServiceOrderRequestDTO, CreateServiceOrderResponseDTO>
     {
          private readonly IServiceOrderRepository _serviceOrderRepository;
          private readonly IServiceOrderFactory _serviceOrderFactory;
          private readonly IDriverRepository _driverRepository;
          private readonly IVehicleRepository _vehicleRepository;
          private readonly IServiceFeeRepository _serviceFeeRepository;
          private readonly IPolicyRepository _policyRepository;
          private readonly IClientRepository _clientRepository;
          private readonly IWorkerRepository _workerRepository;
          private readonly IncidentCostCalculator _incidentCostCalculator;
          private readonly ServiceOrderDomainService _serviceOrderDomainService;

          public CreateServiceOrderService(
              IServiceOrderRepository serviceOrderRepository,
              IServiceOrderFactory serviceOrderFactory,
              IDriverRepository driverRepository,
              IVehicleRepository vehicleRepository,
              IServiceFeeRepository serviceFeeRepository,
              IPolicyRepository policyRepository,
              IClientRepository clientRepository,
              IWorkerRepository workerRepository,
              IncidentCostCalculator incidentCostCalculator,
              ServiceOrderDomainService serviceOrderDomainService)
          {
               _serviceOrderRepository = serviceOrderRepository;
               _serviceOrderFactory = serviceOrderFactory;
               _driverRepository = driverRepository;
               _vehicleRepository = vehicleRepository;
               _serviceFeeRepository = serviceFeeRepository;
               _policyRepository = policyRepository;
               _clientRepository = clientRepository;
               _workerRepository = workerRepository;
               _incidentCostCalculator = incidentCostCalculator;
               _serviceOrderDomainService = serviceOrderDomainService;
          }

          public async Task<CreateServiceOrderResponseDTO> Execute(CreateServiceOrderRequestDTO request)
          {
               if (request.InitialStatus != ServiceOrderStatus.PorAsignar.ToString() && request.InitialStatus != ServiceOrderStatus.PorAceptado.ToString())
               {
                    throw new ArgumentException($"Invalid initial status: {request.InitialStatus}. Allowed statuses are: {ServiceOrderStatus.PorAsignar}, {ServiceOrderStatus.PorAceptado}");
               }

               await ValidateIdsExist(request);
               await _serviceOrderDomainService.ValidateClientCanCreateOrder(request.CustomerId);
               await _serviceOrderDomainService.ValidateDriverCanCreateOrder(request.DriverId, request.VehicleId);

               var incidentCost = await _incidentCostCalculator.CalculateIncidentCost(
                   request.PolicyId,
                   request.ServiceFeeId,
                   new IncidentDistance(request.IncidentDistance)
               );

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
                   new IncidentCost(incidentCost),
                   new PolicyId(request.PolicyId),
                   new StatusServiceOrder(Enum.Parse<ServiceOrderStatus>(request.InitialStatus)),
                   new IncidentDate(venezuelaDateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)),
                   new VehicleId(request.VehicleId),
                   new UserId(request.DriverId),
                   new UserId(request.CustomerId),
                   new UserId(request.OperatorId),
                   new ServiceFeeId(request.ServiceFeeId)
               );

               var serviceOrderDTO = serviceOrder.ToDTO();
               await _serviceOrderRepository.AddServiceOrderAsync(serviceOrderDTO);

               return new CreateServiceOrderResponseDTO
               {
                    Success = true,
                    Message = "Service order created successfully.",
                    UserEmail = request.UserEmail,
                    ServiceOrderId = serviceOrder.Id.Value,
                    TotalPrice = incidentCost
               };
          }

          private async Task ValidateIdsExist(CreateServiceOrderRequestDTO request)
          {
               await _driverRepository.GetDriverByIdAsync(request.DriverId);
               await _vehicleRepository.GetVehicleByIdAsync(request.VehicleId);
               await _serviceFeeRepository.GetServiceFeeByIdAsync(request.ServiceFeeId);
               await _policyRepository.GetPolicyByIdAsync(request.PolicyId);
               await _clientRepository.GetClientByIdAsync(request.CustomerId);
               await _workerRepository.GetWorkerByIdAsync(request.OperatorId);
          }
     }
}