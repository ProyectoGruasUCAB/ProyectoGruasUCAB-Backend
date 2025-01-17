namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class CustomerIdChangedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public UserId NewCustomerId { get; }
          public DateTime Timestamp { get; }

          public CustomerIdChangedEvent(ServiceOrderId serviceOrderId, UserId newCustomerId)
          {
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               NewCustomerId = newCustomerId ?? throw new ArgumentNullException(nameof(newCustomerId), "NewCustomerId cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(CustomerIdChangedEvent);
          public object Context => this;
     }
}