namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class ServiceOrderCreatedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public DateTime Timestamp { get; }

          public ServiceOrderCreatedEvent(ServiceOrderId serviceOrderId)
          {
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(ServiceOrderCreatedEvent);
          public object Context => this;
     }
}