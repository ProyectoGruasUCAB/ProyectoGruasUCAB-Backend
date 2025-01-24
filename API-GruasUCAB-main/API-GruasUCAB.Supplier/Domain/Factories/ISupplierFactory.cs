namespace API_GruasUCAB.Supplier.Domain.Factories
{
     public interface ISupplierFactory
     {
          AggregateRoot.Supplier CreateSupplier(
              SupplierId id,
              SupplierName name,
              SupplierType type);

          Task<AggregateRoot.Supplier> GetSupplierById(SupplierId id);
     }
}