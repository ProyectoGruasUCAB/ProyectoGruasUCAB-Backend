namespace API_GruasUCAB.ServiceOrder.Infrastructure.Mappers
{
     public static class ServiceOrderMapper
     {
          public static ServiceOrderDTO ToDTO(this Domain.AggregateRoot.ServiceOrder serviceOrder)
          {
               return new ServiceOrderDTO
               {
                    ServiceOrderId = serviceOrder.Id.Value,
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
                    StatusServiceOrder = serviceOrder.StatusServiceOrder.Value.ToString(),
                    IncidentDate = serviceOrder.IncidentDate.Value.ToString("yyyy-MM-dd"),
                    VehicleId = serviceOrder.VehicleId.Value,
                    DriverId = serviceOrder.DriverId.Value,
                    CustomerId = serviceOrder.CustomerId.Value,
                    OperatorId = serviceOrder.OperatorId.Value,
                    ServiceFeeId = serviceOrder.ServiceFeeId.Value
               };
          }

          public static Domain.AggregateRoot.ServiceOrder ToEntity(this ServiceOrderDTO serviceOrderDto)
          {
               return new Domain.AggregateRoot.ServiceOrder(
                   new ServiceOrderId(serviceOrderDto.ServiceOrderId),
                   new IncidentDescription(serviceOrderDto.IncidentDescription),
                   new Coordinates(serviceOrderDto.InitialLocationDriverLatitude, serviceOrderDto.InitialLocationDriverLongitude),
                   new Coordinates(serviceOrderDto.IncidentLocationLatitude, serviceOrderDto.IncidentLocationLongitude),
                   new Coordinates(serviceOrderDto.IncidentLocationEndLatitude, serviceOrderDto.IncidentLocationEndLongitude),
                   new IncidentDistance(serviceOrderDto.IncidentDistance),
                   new CustomerVehicleDescription(serviceOrderDto.CustomerVehicleDescription),
                   new IncidentCost(serviceOrderDto.IncidentCost),
                   new PolicyId(serviceOrderDto.PolicyId),
                   new StatusServiceOrder(Enum.Parse<ServiceOrderStatus>(serviceOrderDto.StatusServiceOrder)),
                   new IncidentDate(serviceOrderDto.IncidentDate),
                   new VehicleId(serviceOrderDto.VehicleId),
                   new UserId(serviceOrderDto.DriverId),
                   new UserId(serviceOrderDto.CustomerId),
                   new UserId(serviceOrderDto.OperatorId),
                   new ServiceFeeId(serviceOrderDto.ServiceFeeId)
               );
          }
     }
}