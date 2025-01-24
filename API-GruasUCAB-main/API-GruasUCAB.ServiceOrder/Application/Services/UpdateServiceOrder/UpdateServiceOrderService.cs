namespace API_GruasUCAB.ServiceOrder.Application.Services.UpdateServiceOrder
{
     public class UpdateServiceOrderService : IService<UpdateServiceOrderRequestDTO, UpdateServiceOrderResponseDTO>
     {
          private readonly IServiceOrderRepository _serviceOrderRepository;
          private readonly IServiceOrderFactory _serviceOrderFactory;
          private readonly IDriverRepository _driverRepository;
          private readonly IVehicleRepository _vehicleRepository;
          private readonly IServiceFeeRepository _serviceFeeRepository;
          private readonly IPolicyRepository _policyRepository;
          private readonly IClientRepository _clientRepository;
          private readonly IWorkerRepository _workerRepository;

          public UpdateServiceOrderService(
              IServiceOrderRepository serviceOrderRepository,
              IServiceOrderFactory serviceOrderFactory,
              IDriverRepository driverRepository,
              IVehicleRepository vehicleRepository,
              IServiceFeeRepository serviceFeeRepository,
              IPolicyRepository policyRepository,
              IClientRepository clientRepository,
              IWorkerRepository workerRepository)
          {
               _serviceOrderRepository = serviceOrderRepository;
               _serviceOrderFactory = serviceOrderFactory;
               _driverRepository = driverRepository;
               _vehicleRepository = vehicleRepository;
               _serviceFeeRepository = serviceFeeRepository;
               _policyRepository = policyRepository;
               _clientRepository = clientRepository;
               _workerRepository = workerRepository;
          }

          public async Task<UpdateServiceOrderResponseDTO> Execute(UpdateServiceOrderRequestDTO request)
          {
               await ValidateIdsExist(request);

               var serviceOrderDTO = await _serviceOrderRepository.GetServiceOrderByIdAsync(request.ServiceOrderId)
                   ?? throw new ServiceOrderNotFoundException(request.ServiceOrderId);

               var serviceOrder = serviceOrderDTO.ToEntity();

               if (serviceOrder.StatusServiceOrder.Status >= ServiceOrderStatus.EnProceso)
               {
                    if (!string.IsNullOrEmpty(request.IncidentDescription) ||
                         request.DriverId.HasValue ||
                         request.VehicleId.HasValue ||
                         request.CustomerId.HasValue ||
                         request.ServiceFeeId.HasValue ||
                         request.PolicyId.HasValue ||
                         request.InitialLocationDriverLat.HasValue ||
                         request.InitialLocationDriverLon.HasValue ||
                         request.IncidentLocationLat.HasValue ||
                         request.IncidentLocationLon.HasValue ||
                         request.IncidentLocationEndLat.HasValue ||
                         request.IncidentLocationEndLon.HasValue ||
                         request.IncidentDistance.HasValue ||
                         request.IncidentCost.HasValue)
                    {
                         throw new InvalidOperationException("These fields cannot be changed from the InProcess status.");
                    }
               }

               if (!string.IsNullOrEmpty(request.IncidentDescription))
               {
                    serviceOrder.UpdateIncidentDescription(new IncidentDescription(request.IncidentDescription));
               }

               if (request.InitialLocationDriverLat.HasValue && request.InitialLocationDriverLon.HasValue)
               {
                    serviceOrder.UpdateInitialLocationDriver(new Coordinates(request.InitialLocationDriverLat.Value, request.InitialLocationDriverLon.Value));
               }

               if (request.IncidentLocationLat.HasValue && request.IncidentLocationLon.HasValue)
               {
                    serviceOrder.UpdateIncidentLocation(new Coordinates(request.IncidentLocationLat.Value, request.IncidentLocationLon.Value));
               }

               if (request.IncidentLocationEndLat.HasValue && request.IncidentLocationEndLon.HasValue)
               {
                    serviceOrder.UpdateIncidentLocationEnd(new Coordinates(request.IncidentLocationEndLat.Value, request.IncidentLocationEndLon.Value));
               }

               if (request.IncidentDistance.HasValue)
               {
                    serviceOrder.UpdateIncidentDistance(new IncidentDistance(request.IncidentDistance.Value));
               }

               if (!string.IsNullOrEmpty(request.CustomerVehicleDescription))
               {
                    serviceOrder.UpdateCustomerVehicleDescription(new CustomerVehicleDescription(request.CustomerVehicleDescription));
               }

               if (request.IncidentCost.HasValue)
               {
                    serviceOrder.UpdateIncidentCost(new IncidentCost(request.IncidentCost.Value));
               }

               if (request.PolicyId.HasValue)
               {
                    serviceOrder.UpdatePolicyId(new PolicyId(request.PolicyId.Value));
               }

               if (request.VehicleId.HasValue)
               {
                    serviceOrder.UpdateVehicleId(new VehicleId(request.VehicleId.Value));
               }

               if (request.DriverId.HasValue)
               {
                    serviceOrder.UpdateDriverId(new UserId(request.DriverId.Value));
               }

               if (request.CustomerId.HasValue)
               {
                    serviceOrder.UpdateCustomerId(new UserId(request.CustomerId.Value));
               }

               if (request.OperatorId.HasValue)
               {
                    serviceOrder.UpdateOperatorId(new UserId(request.OperatorId.Value));
               }

               if (request.ServiceFeeId.HasValue)
               {
                    serviceOrder.UpdateServiceFeeId(new ServiceFeeId(request.ServiceFeeId.Value));
               }

               if (!string.IsNullOrEmpty(request.State))
               {
                    var newState = Enum.Parse<ServiceOrderStatus>(request.State);
                    switch (newState)
                    {
                         case ServiceOrderStatus.PorAsignar:
                              serviceOrder.StatusServiceOrder.Assign();
                              break;
                         case ServiceOrderStatus.PorAceptado:
                              serviceOrder.StatusServiceOrder.Assign();
                              break;
                         case ServiceOrderStatus.Aceptado:
                              serviceOrder.StatusServiceOrder.Accept();
                              break;
                         case ServiceOrderStatus.Localizado:
                              serviceOrder.StatusServiceOrder.Locate();
                              break;
                         case ServiceOrderStatus.EnProceso:
                              serviceOrder.StatusServiceOrder.Process();
                              break;
                         case ServiceOrderStatus.Finalizado:
                              serviceOrder.StatusServiceOrder.Finish();
                              break;
                         case ServiceOrderStatus.Cancelado:
                              serviceOrder.StatusServiceOrder.Cancel();
                              break;
                         case ServiceOrderStatus.CanceladoPorCobrar:
                              serviceOrder.StatusServiceOrder.CancelForCharge();
                              break;
                         case ServiceOrderStatus.Pagado:
                              serviceOrder.StatusServiceOrder.Pay();
                              break;
                         default:
                              throw new InvalidOperationException("Invalid state transition.");
                    }
               }

               var updatedServiceOrderDTO = serviceOrder.ToDTO();
               await _serviceOrderRepository.UpdateServiceOrderAsync(updatedServiceOrderDTO);

               return new UpdateServiceOrderResponseDTO
               {
                    Success = true,
                    Message = "Service order updated successfully",
                    UserEmail = request.UserEmail,
                    ServiceOrderId = serviceOrder.Id.Value,
               };
          }

          private async Task ValidateIdsExist(UpdateServiceOrderRequestDTO request)
          {
               if (request.DriverId.HasValue)
               {
                    await _driverRepository.GetDriverByIdAsync(request.DriverId.Value);
               }

               if (request.VehicleId.HasValue)
               {
                    await _vehicleRepository.GetVehicleByIdAsync(request.VehicleId.Value);
               }

               if (request.ServiceFeeId.HasValue)
               {
                    await _serviceFeeRepository.GetServiceFeeByIdAsync(request.ServiceFeeId.Value);
               }

               if (request.PolicyId.HasValue)
               {
                    await _policyRepository.GetPolicyByIdAsync(request.PolicyId.Value);
               }

               if (request.CustomerId.HasValue)
               {
                    await _clientRepository.GetClientByIdAsync(request.CustomerId.Value);
               }

               if (request.OperatorId.HasValue)
               {
                    await _workerRepository.GetWorkerByIdAsync(request.OperatorId.Value);
               }
          }
     }
}