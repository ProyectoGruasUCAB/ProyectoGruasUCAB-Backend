namespace API_GruasUCAB.Supplier.Domain.Events
{
     public class SupplierTypeChangedEvent : IDomainEvent
     {
          public SupplierId SupplierId { get; }
          public SupplierType NewType { get; }
          public DateTime Timestamp { get; }

          public SupplierTypeChangedEvent(SupplierId supplierId, SupplierType newType)
          {
               SupplierId = supplierId ?? throw new ArgumentNullException(nameof(supplierId), "SupplierId cannot be null.");
               NewType = newType ?? throw new ArgumentNullException(nameof(newType), "NewType cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => SupplierId.ToString();
          public string Name => nameof(SupplierTypeChangedEvent);
          public object Context => this;
     }
}