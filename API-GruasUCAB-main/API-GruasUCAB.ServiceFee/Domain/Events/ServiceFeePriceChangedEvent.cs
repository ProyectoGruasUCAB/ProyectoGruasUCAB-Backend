namespace API_GruasUCAB.ServiceFee.Domain.Events
{
     public class ServiceFeePriceChangedEvent : IDomainEvent
     {
          public ServiceFeeId ServiceFeeId { get; }
          public ServiceFeePrice NewPrice { get; }
          public DateTime Timestamp { get; }

          public ServiceFeePriceChangedEvent(ServiceFeeId serviceFeeId, ServiceFeePrice newPrice)
          {
               ServiceFeeId = serviceFeeId ?? throw new ArgumentNullException(nameof(serviceFeeId), "ServiceFeeId cannot be null.");
               NewPrice = newPrice ?? throw new ArgumentNullException(nameof(newPrice), "NewPrice cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceFeeId.ToString();
          public string Name => nameof(ServiceFeePriceChangedEvent);
          public object Context => this;
     }
}