namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class ServiceFeeIdChangedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public ServiceFeeId NewServiceFeeId { get; }
          public DateTime Timestamp { get; }

          public ServiceFeeIdChangedEvent(ServiceOrderId serviceOrderId, ServiceFeeId newServiceFeeId)
          {
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               NewServiceFeeId = newServiceFeeId ?? throw new ArgumentNullException(nameof(newServiceFeeId), "NewServiceFeeId cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(ServiceFeeIdChangedEvent);
          public object Context => this;
     }
}