namespace API_GruasUCAB.ServiceFee.Domain.Events
{
     public class ServiceFeePriceKmChangedEvent : IDomainEvent
     {
          public ServiceFeeId ServiceFeeId { get; }
          public ServiceFeePriceKm NewPriceKm { get; }
          public DateTime Timestamp { get; }

          public ServiceFeePriceKmChangedEvent(ServiceFeeId serviceFeeId, ServiceFeePriceKm newPriceKm)
          {
               ServiceFeeId = serviceFeeId ?? throw new ArgumentNullException(nameof(serviceFeeId), "ServiceFeeId cannot be null.");
               NewPriceKm = newPriceKm ?? throw new ArgumentNullException(nameof(newPriceKm), "NewPriceKm cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceFeeId.ToString();
          public string Name => nameof(ServiceFeePriceKmChangedEvent);
          public object Context => this;
     }
}