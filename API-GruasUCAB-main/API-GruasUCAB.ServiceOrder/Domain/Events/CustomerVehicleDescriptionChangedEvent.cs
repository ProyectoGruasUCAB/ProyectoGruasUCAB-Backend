namespace API_GruasUCAB.ServiceOrder.Domain.Events
{
     public class CustomerVehicleDescriptionChangedEvent : IDomainEvent
     {
          public ServiceOrderId ServiceOrderId { get; }
          public CustomerVehicleDescription NewDescription { get; }
          public DateTime Timestamp { get; }

          public CustomerVehicleDescriptionChangedEvent(ServiceOrderId serviceOrderId, CustomerVehicleDescription newDescription)
          {
               ServiceOrderId = serviceOrderId ?? throw new ArgumentNullException(nameof(serviceOrderId), "ServiceOrderId cannot be null.");
               NewDescription = newDescription ?? throw new ArgumentNullException(nameof(newDescription), "NewDescription cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => ServiceOrderId.ToString();
          public string Name => nameof(CustomerVehicleDescriptionChangedEvent);
          public object Context => this;
     }
}