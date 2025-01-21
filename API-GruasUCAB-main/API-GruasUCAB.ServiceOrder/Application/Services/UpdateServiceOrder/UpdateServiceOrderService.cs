namespace API_GruasUCAB.ServiceOrder.Application.Services.UpdateServiceOrder
{
     public class UpdateServiceOrderService : IService<UpdateServiceOrderRequestDTO, UpdateServiceOrderResponseDTO>
     {
          private readonly IServiceOrderRepository _serviceOrderRepository;
          private readonly IServiceOrderFactory _serviceOrderFactory;

          public UpdateServiceOrderService(IServiceOrderRepository serviceOrderRepository, IServiceOrderFactory serviceOrderFactory)
          {
               _serviceOrderRepository = serviceOrderRepository;
               _serviceOrderFactory = serviceOrderFactory;
          }

          public async Task<UpdateServiceOrderResponseDTO> Execute(UpdateServiceOrderRequestDTO request)
          {
               var serviceOrderDTO = await _serviceOrderRepository.GetServiceOrderByIdAsync(request.ServiceOrderId)
                   ?? throw new ServiceOrderNotFoundException(request.ServiceOrderId);

               var serviceOrder = _serviceOrderFactory.CreateServiceOrder(
                   new ServiceOrderId(serviceOrderDTO.ServiceOrderId),
                   new IncidentDescription(serviceOrderDTO.IncidentDescription),
                   new Coordinates(serviceOrderDTO.InitialLocationDriverLatitude, serviceOrderDTO.InitialLocationDriverLongitude),
                   new Coordinates(serviceOrderDTO.IncidentLocationLatitude, serviceOrderDTO.IncidentLocationLongitude),
                   new Coordinates(serviceOrderDTO.IncidentLocationEndLatitude, serviceOrderDTO.IncidentLocationEndLongitude),
                   new IncidentDistance(serviceOrderDTO.IncidentDistance),
                   new CustomerVehicleDescription(serviceOrderDTO.CustomerVehicleDescription),
                   new IncidentCost(serviceOrderDTO.IncidentCost),
                   new PolicyId(serviceOrderDTO.PolicyId),
                   new StatusServiceOrder(Enum.Parse<ServiceOrderStatus>(serviceOrderDTO.StatusServiceOrder)),
                   new IncidentDate(serviceOrderDTO.IncidentDate),
                   new VehicleId(serviceOrderDTO.VehicleId),
                   new UserId(serviceOrderDTO.DriverId),
                   new UserId(serviceOrderDTO.CustomerId),
                   new UserId(serviceOrderDTO.OperatorId),
                   new ServiceFeeId(serviceOrderDTO.ServiceFeeId)
               );

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

               serviceOrderDTO.InitialLocationDriverLatitude = (float)serviceOrder.InitialLocationDriver.Latitude;
               serviceOrderDTO.InitialLocationDriverLongitude = (float)serviceOrder.InitialLocationDriver.Longitude;
               serviceOrderDTO.IncidentLocationLatitude = (float)serviceOrder.IncidentLocation.Latitude;
               serviceOrderDTO.IncidentLocationLongitude = (float)serviceOrder.IncidentLocation.Longitude;
               serviceOrderDTO.IncidentLocationEndLatitude = (float)serviceOrder.IncidentLocationEnd.Latitude;
               serviceOrderDTO.IncidentLocationEndLongitude = (float)serviceOrder.IncidentLocationEnd.Longitude;
               serviceOrderDTO.IncidentDistance = serviceOrder.IncidentDistance.Value;
               serviceOrderDTO.CustomerVehicleDescription = serviceOrder.CustomerVehicleDescription.Value;
               serviceOrderDTO.IncidentCost = serviceOrder.IncidentCost.Value;
               serviceOrderDTO.PolicyId = serviceOrder.PolicyId.Id;
               serviceOrderDTO.StatusServiceOrder = serviceOrder.StatusServiceOrder.Status.ToString();
               serviceOrderDTO.IncidentDate = serviceOrder.IncidentDate.Value.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
               serviceOrderDTO.VehicleId = serviceOrder.VehicleId.Id;
               serviceOrderDTO.DriverId = serviceOrder.DriverId.Id;
               serviceOrderDTO.CustomerId = serviceOrder.CustomerId.Id;
               serviceOrderDTO.OperatorId = serviceOrder.OperatorId.Id;
               serviceOrderDTO.ServiceFeeId = serviceOrder.ServiceFeeId.Id;

               await _serviceOrderRepository.UpdateServiceOrderAsync(serviceOrderDTO);

               return new UpdateServiceOrderResponseDTO
               {
                    Success = true,
                    Message = "Service order updated successfully",
                    UserEmail = request.UserEmail,
                    ServiceOrderId = serviceOrder.Id.Id,
               };
          }
     }
}