namespace API_GruasUCAB.Supplier.Domain.Factories
{
     public class SupplierFactory : ISupplierFactory
     {
          public AggregateRoot.Supplier CreateSupplier(
              SupplierId id,
              SupplierName name,
              SupplierType type)
          {
               return new AggregateRoot.Supplier(id, name, type);
          }

          public async Task<AggregateRoot.Supplier> GetSupplierById(SupplierId id)
          {
               // Implementa la lógica para obtener el proveedor por su ID
               // Esto puede involucrar una llamada a un repositorio o una base de datos
               // Aquí se usa Task.FromResult como un ejemplo de implementación asincrónica
               return await Task.FromResult(new AggregateRoot.Supplier(id, new SupplierName("Example"), new SupplierType(SupplierTypeEnum.Externo)));
          }
     }
}