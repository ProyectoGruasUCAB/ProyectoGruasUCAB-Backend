namespace API_GruasUCAB.Users.Domain.Events
{
     public class SupplierIdChangedEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public SupplierId NewSupplierId { get; }
          public DateTime Timestamp { get; }

          public SupplierIdChangedEvent(UserId userId, SupplierId newSupplierId)
          {
               UserId = userId ?? throw new ArgumentNullException(nameof(userId), "UserId cannot be null.");
               NewSupplierId = newSupplierId ?? throw new ArgumentNullException(nameof(newSupplierId), "NewSupplierId cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => UserId.ToString();
          public string Name => nameof(SupplierIdChangedEvent);
          public object Context => this;
     }
}