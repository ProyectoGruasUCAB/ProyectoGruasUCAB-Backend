namespace API_GruasUCAB.ServiceOrder.Domain.Factories
{
     public class ServiceOrderFactory : IServiceOrderFactory
     {
          public Domain.AggregateRoot.ServiceOrder CreateServiceOrder(
              ServiceOrderId serviceOrderId,
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
               return new Domain.AggregateRoot.ServiceOrder(
                   serviceOrderId,
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
                   serviceFeeId
               );
          }
     }
}