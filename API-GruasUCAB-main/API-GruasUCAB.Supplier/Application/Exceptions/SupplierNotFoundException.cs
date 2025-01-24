namespace API_GruasUCAB.Supplier.Application.Exceptions
{
     public class SupplierNotFoundException : Exception
     {
          public SupplierNotFoundException(Guid SupplierId)
              : base($"Supplier with ID {SupplierId} not found.")
          {
          }
     }
}