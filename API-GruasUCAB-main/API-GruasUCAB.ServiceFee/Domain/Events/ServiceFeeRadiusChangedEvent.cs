namespace API_GruasUCAB.ServiceFee.Domain.Events
{
     public class ServiceFeeRadiusChangedEvent : IDomainEvent
     {
          public ServiceFeeId ServiceFeeId { get; }
          public ServiceFeeRadius NewRadius { get; }
          public DateTime Timestamp { get; }

          public ServiceFeeRadiusChangedEvent(ServiceFeeId serviceFeeId, ServiceFeeRadius newRadius)
          {
               ServiceFeeId = serviceFeeId ?? throw new ArgumentNullException(nameof(serviceFeeId), "ServiceFeeId cannot be null.");
               NewRadius = newRadius ?? throw new ArgumentNullException(nameof(newRadius), "NewRadius cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceFeeId.ToString();
          public string Name => nameof(ServiceFeeRadiusChangedEvent);
          public object Context => this;
     }
}