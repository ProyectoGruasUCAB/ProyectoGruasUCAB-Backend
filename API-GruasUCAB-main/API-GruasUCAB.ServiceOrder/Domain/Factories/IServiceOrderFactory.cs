namespace API_GruasUCAB.ServiceOrder.Domain.Factories
{
     public interface IServiceOrderFactory
     {
          AggregateRoot.ServiceOrder CreateServiceOrder(
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
              ServiceFeeId serviceFeeId);
     }
}