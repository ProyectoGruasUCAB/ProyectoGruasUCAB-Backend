namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class IncidentCostChangedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public IncidentCost NewCost { get; }
          public DateTime Timestamp { get; }

          public IncidentCostChangedEvent(ServiceOrderId serviceOrderId, IncidentCost newCost)
          {
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               NewCost = newCost ?? throw new ArgumentNullException(nameof(newCost), "NewCost cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(IncidentCostChangedEvent);
          public object Context => this;
     }
}