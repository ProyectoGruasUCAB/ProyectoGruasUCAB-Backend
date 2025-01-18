namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class VehicleIdChangedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public VehicleId NewVehicleId { get; }
          public DateTime Timestamp { get; }

          public VehicleIdChangedEvent(ServiceOrderId serviceOrderId, VehicleId newVehicleId)
          {
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               NewVehicleId = newVehicleId ?? throw new ArgumentNullException(nameof(newVehicleId), "NewVehicleId cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(VehicleIdChangedEvent);
          public object Context => this;
     }
}