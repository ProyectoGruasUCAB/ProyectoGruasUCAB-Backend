namespace API_GruasUCAB.ServiceFee.Domain.Events
{
     public class ServiceFeeCreatedEvent : IDomainEvent
     {
          public ServiceFeeId ServiceFeeId { get; }
          public ServiceFeeName ServiceName { get; }
          public ServiceFeePrice Price { get; }
          public ServiceFeePriceKm PriceKm { get; }
          public ServiceFeeRadius Radius { get; }
          public DateTime Timestamp { get; }

          public ServiceFeeCreatedEvent(ServiceFeeId serviceFeeId, ServiceFeeName serviceName, ServiceFeePrice price, ServiceFeePriceKm priceKm, ServiceFeeRadius radius)
          {
               ServiceFeeId = serviceFeeId ?? throw new ArgumentNullException(nameof(serviceFeeId), "ServiceFeeId cannot be null.");
               ServiceName = serviceName ?? throw new ArgumentNullException(nameof(serviceName), "ServiceName cannot be null.");
               Price = price ?? throw new ArgumentNullException(nameof(price), "Price cannot be null.");
               PriceKm = priceKm ?? throw new ArgumentNullException(nameof(priceKm), "PriceKm cannot be null.");
               Radius = radius ?? throw new ArgumentNullException(nameof(radius), "Radius cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceFeeId.ToString();
          public string Name => nameof(ServiceFeeCreatedEvent);
          public object Context => this;
     }
}