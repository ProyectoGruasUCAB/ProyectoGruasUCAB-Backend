namespace API_GruasUCAB.Supplier.Domain.Events
{
     public class SupplierNameChangedEvent : IDomainEvent
     {
          public SupplierId SupplierId { get; }
          public SupplierName NewName { get; }
          public DateTime Timestamp { get; }

          public SupplierNameChangedEvent(SupplierId supplierId, SupplierName newName)
          {
               SupplierId = supplierId ?? throw new ArgumentNullException(nameof(supplierId), "SupplierId cannot be null.");
               NewName = newName ?? throw new ArgumentNullException(nameof(newName), "NewName cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => SupplierId.ToString();
          public string Name => nameof(SupplierNameChangedEvent);
          public object Context => this;
     }
}