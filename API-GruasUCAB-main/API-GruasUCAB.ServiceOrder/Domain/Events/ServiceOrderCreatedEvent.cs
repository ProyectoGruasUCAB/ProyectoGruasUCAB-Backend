namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class ServiceOrderCreatedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public IncidentDescription IncidentDescription { get; }
          public Coordinates InitialLocationDriver { get; }
          public Coordinates IncidentLocation { get; }
          public Coordinates IncidentLocationEnd { get; }
          public IncidentDistance IncidentDistance { get; }
          public CustomerVehicleDescription CustomerVehicleDescription { get; }
          public IncidentCost IncidentCost { get; }
          public PolicyId PolicyId { get; }
          public StatusServiceOrder StatusServiceOrder { get; }
          public IncidentDate IncidentDate { get; }
          public VehicleId VehicleId { get; }
          public UserId DriverId { get; }
          public UserId CustomerId { get; }
          public UserId OperatorId { get; }
          public ServiceFeeId ServiceFeeId { get; }
          public DateTime Timestamp { get; }

          public ServiceOrderCreatedEvent(
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
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               IncidentDescription = incidentDescription ?? throw new ArgumentNullException(nameof(incidentDescription), "IncidentDescription cannot be null.");
               InitialLocationDriver = initialLocationDriver ?? throw new ArgumentNullException(nameof(initialLocationDriver), "InitialLocationDriver cannot be null.");
               IncidentLocation = incidentLocation ?? throw new ArgumentNullException(nameof(incidentLocation), "IncidentLocation cannot be null.");
               IncidentLocationEnd = incidentLocationEnd ?? throw new ArgumentNullException(nameof(incidentLocationEnd), "IncidentLocationEnd cannot be null.");
               IncidentDistance = incidentDistance ?? throw new ArgumentNullException(nameof(incidentDistance), "IncidentDistance cannot be null.");
               CustomerVehicleDescription = customerVehicleDescription ?? throw new ArgumentNullException(nameof(customerVehicleDescription), "CustomerVehicleDescription cannot be null.");
               IncidentCost = incidentCost ?? throw new ArgumentNullException(nameof(incidentCost), "IncidentCost cannot be null.");
               PolicyId = policyId ?? throw new ArgumentNullException(nameof(policyId), "PolicyId cannot be null.");
               StatusServiceOrder = statusServiceOrder ?? throw new ArgumentNullException(nameof(statusServiceOrder), "StatusServiceOrder cannot be null.");
               IncidentDate = incidentDate ?? throw new ArgumentNullException(nameof(incidentDate), "IncidentDate cannot be null.");
               VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId), "VehicleId cannot be null.");
               DriverId = driverId ?? throw new ArgumentNullException(nameof(driverId), "DriverId cannot be null.");
               CustomerId = customerId ?? throw new ArgumentNullException(nameof(customerId), "CustomerId cannot be null.");
               OperatorId = operatorId ?? throw new ArgumentNullException(nameof(operatorId), "OperatorId cannot be null.");
               ServiceFeeId = serviceFeeId ?? throw new ArgumentNullException(nameof(serviceFeeId), "ServiceFeeId cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(ServiceOrderCreatedEvent);
          public object Context => this;
     }
}