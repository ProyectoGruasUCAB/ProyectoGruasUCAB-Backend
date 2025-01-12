namespace API_GruasUCAB.ServiceFee.Domain.Events
{
     public class ServiceFeeNameChangedEvent : IDomainEvent
     {
          public ServiceFeeId ServiceFeeId { get; }
          public ServiceFeeName NewName { get; }
          public DateTime Timestamp { get; }

          public ServiceFeeNameChangedEvent(ServiceFeeId serviceFeeId, ServiceFeeName newName)
          {
               ServiceFeeId = serviceFeeId ?? throw new ArgumentNullException(nameof(serviceFeeId), "ServiceFeeId cannot be null.");
               NewName = newName ?? throw new ArgumentNullException(nameof(newName), "NewName cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceFeeId.ToString();
          public string Name => nameof(ServiceFeeNameChangedEvent);
          public object Context => this;
     }
}