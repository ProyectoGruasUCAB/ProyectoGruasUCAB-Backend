namespace API_GruasUCAB.ServiceFee.Domain.Events
{
     public class ServiceFeeDescriptionChangedEvent : IDomainEvent
     {
          public ServiceFeeId ServiceFeeId { get; }
          public ServiceFeeDescription NewDescription { get; }
          public DateTime Timestamp { get; }

          public ServiceFeeDescriptionChangedEvent(ServiceFeeId serviceFeeId, ServiceFeeDescription newDescription)
          {
               ServiceFeeId = serviceFeeId ?? throw new ArgumentNullException(nameof(serviceFeeId), "ServiceFeeId cannot be null.");
               NewDescription = newDescription ?? throw new ArgumentNullException(nameof(newDescription), "NewDescription cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceFeeId.ToString();
          public string Name => nameof(ServiceFeeDescriptionChangedEvent);
          public object Context => this;
     }
}