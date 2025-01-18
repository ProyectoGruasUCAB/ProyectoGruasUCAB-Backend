namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class OperatorIdChangedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public UserId NewOperatorId { get; }
          public DateTime Timestamp { get; }

          public OperatorIdChangedEvent(ServiceOrderId serviceOrderId, UserId newOperatorId)
          {
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               NewOperatorId = newOperatorId ?? throw new ArgumentNullException(nameof(newOperatorId), "NewOperatorId cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(OperatorIdChangedEvent);
          public object Context => this;
     }
}