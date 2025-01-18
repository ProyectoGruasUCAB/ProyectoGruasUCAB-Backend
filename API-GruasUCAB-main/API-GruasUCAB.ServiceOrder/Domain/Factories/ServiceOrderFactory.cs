namespace API_GruasUCAB.ServiceOrder.Domain.Factories
{
     public class ServiceOrderFactory : IServiceOrderFactory
     {
          private readonly IServiceOrderRepository _serviceOrderRepository;

          public ServiceOrderFactory(IServiceOrderRepository serviceOrderRepository)
          {
               _serviceOrderRepository = serviceOrderRepository;
          }

          public AggregateRoot.ServiceOrder CreateServiceOrder(
              ServiceOrderId id,
              IncidentDescription incidentDescription,
              Coordinates initialLocationDriver,
              Coordinates incidentLocation,
              Coordinates incidentLocationEnd,
              IncidentDistance incidentDistance,
              CustomerVehicleDescription customerVehicleDescription,
              IncidentCost incidentCost,
              PolicyId policyId,
              StatusServiceOrder statusServiceOrder,
              IncidentDate incidentDate,
              VehicleId vehicleId,
              UserId driverId,
              UserId customerId,
              UserId operatorId,
              ServiceFeeId serviceFeeId)
          {
               return new AggregateRoot.ServiceOrder(
                   id,
                   incidentDescription,
                   initialLocationDriver,
                   incidentLocation,
                   incidentLocationEnd,
                   incidentDistance,
                   customerVehicleDescription,
                   incidentCost,
                   policyId,
                   statusServiceOrder,
                   incidentDate,
                   vehicleId,
                   driverId,
                   customerId,
                   operatorId,
                   serviceFeeId);
          }

          public async Task<AggregateRoot.ServiceOrder?> GetServiceOrderById(ServiceOrderId id)
          {
               var serviceOrderDTO = await _serviceOrderRepository.GetServiceOrderByIdAsync(id.Id);
               if (serviceOrderDTO == null)
               {
                    throw new ServiceOrderNotFoundException(id.Id);
               }

               var incidentDate = new IncidentDate(serviceOrderDTO.IncidentDate);
               var statusServiceOrder = Enum.TryParse<ServiceOrderStatus>(serviceOrderDTO.StatusServiceOrder, out var status)
                   ? new StatusServiceOrder(status)
                   : throw new InvalidStatusServiceOrderException();

               return new AggregateRoot.ServiceOrder(
                   new ServiceOrderId(serviceOrderDTO.ServiceOrderId),
                   new IncidentDescription(serviceOrderDTO.IncidentDescription),
                   new Coordinates(serviceOrderDTO.InitialLocationDriverLat, serviceOrderDTO.InitialLocationDriverLon),
                   new Coordinates(serviceOrderDTO.IncidentLocationLat, serviceOrderDTO.IncidentLocationLon),
                   new Coordinates(serviceOrderDTO.IncidentLocationEndLat, serviceOrderDTO.IncidentLocationEndLon),
                   new IncidentDistance(serviceOrderDTO.IncidentDistance),
                   new CustomerVehicleDescription(serviceOrderDTO.CustomerVehicleDescription),
                   new IncidentCost(serviceOrderDTO.IncidentCost),
                   new PolicyId(serviceOrderDTO.PolicyId),
                   statusServiceOrder,
                   incidentDate,
                   new VehicleId(serviceOrderDTO.VehicleId),
                   new UserId(serviceOrderDTO.DriverId),
                   new UserId(serviceOrderDTO.CustomerId),
                   new UserId(serviceOrderDTO.OperatorId),
                   new ServiceFeeId(serviceOrderDTO.ServiceFeeId));
          }
     }
}