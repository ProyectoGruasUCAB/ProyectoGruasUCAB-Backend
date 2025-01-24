namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class PolicyIdChangedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public PolicyId NewPolicyId { get; }
          public DateTime Timestamp { get; }

          public PolicyIdChangedEvent(ServiceOrderId serviceOrderId, PolicyId newPolicyId)
          {
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               NewPolicyId = newPolicyId ?? throw new ArgumentNullException(nameof(newPolicyId), "NewPolicyId cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(PolicyIdChangedEvent);
          public object Context => this;
     }
}