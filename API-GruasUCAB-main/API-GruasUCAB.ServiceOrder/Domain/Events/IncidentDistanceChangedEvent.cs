namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class IncidentDistanceChangedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public IncidentDistance NewDistance { get; }
          public DateTime Timestamp { get; }

          public IncidentDistanceChangedEvent(ServiceOrderId serviceOrderId, IncidentDistance newDistance)
          {
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               NewDistance = newDistance ?? throw new ArgumentNullException(nameof(newDistance), "NewDistance cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(IncidentDistanceChangedEvent);
          public object Context => this;
     }
}