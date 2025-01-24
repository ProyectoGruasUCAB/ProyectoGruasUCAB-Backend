namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class IncidentDateChangedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public IncidentDate NewDate { get; }
          public DateTime Timestamp { get; }

          public IncidentDateChangedEvent(ServiceOrderId serviceOrderId, IncidentDate newDate)
          {
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               NewDate = newDate ?? throw new ArgumentNullException(nameof(newDate), "NewDate cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(IncidentDateChangedEvent);
          public object Context => this;
     }
}