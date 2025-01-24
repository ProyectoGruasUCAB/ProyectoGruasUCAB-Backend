namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class StatusServiceOrderChangedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public StatusServiceOrder NewStatus { get; }
          public DateTime Timestamp { get; }

          public StatusServiceOrderChangedEvent(ServiceOrderId serviceOrderId, StatusServiceOrder newStatus)
          {
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               NewStatus = newStatus ?? throw new ArgumentNullException(nameof(newStatus), "NewStatus cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(StatusServiceOrderChangedEvent);
          public object Context => this;
     }
}