namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class DriverIdChangedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public UserId NewDriverId { get; }
          public DateTime Timestamp { get; }

          public DriverIdChangedEvent(ServiceOrderId serviceOrderId, UserId newDriverId)
          {
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               NewDriverId = newDriverId ?? throw new ArgumentNullException(nameof(newDriverId), "NewDriverId cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(DriverIdChangedEvent);
          public object Context => this;
     }
}