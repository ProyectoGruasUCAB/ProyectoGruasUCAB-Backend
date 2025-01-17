namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class IncidentLocationEndChangedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public Coordinates NewLocation { get; }
          public DateTime Timestamp { get; }

          public IncidentLocationEndChangedEvent(ServiceOrderId serviceOrderId, Coordinates newLocation)
          {
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               NewLocation = newLocation ?? throw new ArgumentNullException(nameof(newLocation), "NewLocation cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(IncidentLocationEndChangedEvent);
          public object Context => this;
     }
}