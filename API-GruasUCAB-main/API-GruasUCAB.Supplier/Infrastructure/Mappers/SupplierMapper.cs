namespace API_GruasUCAB.Supplier.Infrastructure.Mappers
{
     public static class SupplierMapper
     {
          public static SupplierDTO ToDTO(this Domain.AggregateRoot.Supplier supplier)
          {
               return new SupplierDTO
               {
                    SupplierId = supplier.Id.Value,
                    Name = supplier.Name.Value,
                    Type = supplier.Type.Value.ToString()
               };
          }

          public static Domain.AggregateRoot.Supplier ToEntity(this SupplierDTO supplierDto)
          {
               if (!Enum.TryParse(supplierDto.Type, out SupplierTypeEnum typeEnum))
               {
                    throw new ArgumentException($"Invalid supplier type: {supplierDto.Type}");
               }

               return new Domain.AggregateRoot.Supplier(
                   new SupplierId(supplierDto.SupplierId),
                   new SupplierName(supplierDto.Name),
                   new SupplierType(typeEnum)
               );
          }
     }
}