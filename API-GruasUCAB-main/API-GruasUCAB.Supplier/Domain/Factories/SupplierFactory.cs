namespace API_GruasUCAB.Supplier.Domain.Factories
{
     public class SupplierFactory : ISupplierFactory
     {
          private readonly ISupplierRepository _supplierRepository;

          public SupplierFactory(ISupplierRepository supplierRepository)
          {
               _supplierRepository = supplierRepository;
          }

          public AggregateRoot.Supplier CreateSupplier(
              SupplierId id,
              SupplierName name,
              SupplierType type)
          {
               return new AggregateRoot.Supplier(id, name, type);
          }

          public async Task<AggregateRoot.Supplier> GetSupplierById(SupplierId id)
          {
               var supplierDTO = await _supplierRepository.GetSupplierByIdAsync(id.Id);
               return new AggregateRoot.Supplier(
                   new SupplierId(supplierDTO.SupplierId),
                   new SupplierName(supplierDTO.Name),
                   new SupplierType(Enum.Parse<SupplierTypeEnum>(supplierDTO.Type))
               );
          }
     }
}