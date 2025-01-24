namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class IncidentDescriptionChangedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public IncidentDescription NewDescription { get; }
          public DateTime Timestamp { get; }

          public IncidentDescriptionChangedEvent(ServiceOrderId serviceOrderId, IncidentDescription newDescription)
          {
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               NewDescription = newDescription ?? throw new ArgumentNullException(nameof(newDescription), "NewDescription cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(IncidentDescriptionChangedEvent);
          public object Context => this;
     }
}