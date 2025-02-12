namespace API_GruasUCAB.ServiceOrder.Domain.AggregateRoot
{
     public partial class ServiceOrder : AggregateRoot<ServiceOrderId>
     {
          public IncidentDescription IncidentDescription { get; private set; }
          public Coordinates InitialLocationDriver { get; private set; }
          public Coordinates IncidentLocation { get; private set; }
          public Coordinates IncidentLocationEnd { get; private set; }
          public IncidentDistance IncidentDistance { get; private set; }
          public CustomerVehicleDescription CustomerVehicleDescription { get; private set; }
          public IncidentCost IncidentCost { get; private set; }
          public PolicyId PolicyId { get; private set; }
          public StatusServiceOrder StatusServiceOrder { get; private set; }
          public IncidentDate IncidentDate { get; private set; }
          public VehicleId VehicleId { get; private set; }
          public UserId DriverId { get; private set; }
          public UserId CustomerId { get; private set; }
          public UserId OperatorId { get; private set; }
          public ServiceFeeId ServiceFeeId { get; private set; }

          public ServiceOrder(
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
              ServiceFeeId serviceFeeId) : base(serviceOrderId)
          {
               IncidentDescription = incidentDescription ?? throw new ArgumentNullException(nameof(incidentDescription));
               InitialLocationDriver = initialLocationDriver ?? throw new ArgumentNullException(nameof(initialLocationDriver));
               IncidentLocation = incidentLocation ?? throw new ArgumentNullException(nameof(incidentLocation));
               IncidentLocationEnd = incidentLocationEnd ?? throw new ArgumentNullException(nameof(incidentLocationEnd));
               IncidentDistance = incidentDistance ?? throw new ArgumentNullException(nameof(incidentDistance));
               CustomerVehicleDescription = customerVehicleDescription ?? throw new ArgumentNullException(nameof(customerVehicleDescription));
               IncidentCost = incidentCost ?? throw new ArgumentNullException(nameof(incidentCost));
               PolicyId = policyId ?? throw new ArgumentNullException(nameof(policyId));
               StatusServiceOrder = statusServiceOrder ?? throw new ArgumentNullException(nameof(statusServiceOrder));
               IncidentDate = incidentDate ?? throw new ArgumentNullException(nameof(incidentDate));
               VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId));
               DriverId = driverId ?? throw new ArgumentNullException(nameof(driverId));
               CustomerId = customerId ?? throw new ArgumentNullException(nameof(customerId));
               OperatorId = operatorId ?? throw new ArgumentNullException(nameof(operatorId));
               ServiceFeeId = serviceFeeId ?? throw new ArgumentNullException(nameof(serviceFeeId));

               ValidateState();
               AddDomainEvent(new ServiceOrderCreatedEvent(
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
               ));

          }

          private ServiceOrder() : base(new ServiceOrderId(Guid.NewGuid()))
          {
               IncidentDescription = new IncidentDescription("Default Description");
               InitialLocationDriver = new Coordinates(0, 0);
               IncidentLocation = new Coordinates(0, 0);
               IncidentLocationEnd = new Coordinates(0, 0);
               IncidentDistance = new IncidentDistance(05);
               CustomerVehicleDescription = new CustomerVehicleDescription("Default Vehicle Description");
               IncidentCost = new IncidentCost(04);
               PolicyId = new PolicyId(Guid.NewGuid());
               StatusServiceOrder = new StatusServiceOrder(ServiceOrderStatus.PorAsignar);
               IncidentDate = new IncidentDate(DateTime.Now.ToString("dd-MM-yyyy"));
               VehicleId = new VehicleId(Guid.NewGuid());
               DriverId = new UserId(Guid.NewGuid());
               CustomerId = new UserId(Guid.NewGuid());
               OperatorId = new UserId(Guid.NewGuid());
               ServiceFeeId = new ServiceFeeId(Guid.NewGuid());
          }
     }
}