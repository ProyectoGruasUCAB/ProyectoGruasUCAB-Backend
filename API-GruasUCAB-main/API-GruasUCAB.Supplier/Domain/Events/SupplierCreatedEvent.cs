namespace API_GruasUCAB.Supplier.Domain.Events
{
     public class SupplierCreatedEvent : IDomainEvent
     {
          public SupplierId SupplierId { get; }
          public SupplierName SupplierName { get; }
          public SupplierType SupplierType { get; }
          public DateTime Timestamp { get; }

          public SupplierCreatedEvent(SupplierId supplierId, SupplierName supplierName, SupplierType supplierType)
          {
               SupplierId = supplierId ?? throw new ArgumentNullException(nameof(supplierId), "SupplierId cannot be null.");
               SupplierName = supplierName ?? throw new ArgumentNullException(nameof(supplierName), "SupplierName cannot be null.");
               SupplierType = supplierType ?? throw new ArgumentNullException(nameof(supplierType), "SupplierType cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => SupplierId.ToString();
          public string Name => nameof(SupplierCreatedEvent);
          public object Context => this;
     }
}