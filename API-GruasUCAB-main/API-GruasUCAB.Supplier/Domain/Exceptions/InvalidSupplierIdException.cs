using API_GruasUCAB.Core.Domain.DomainException;

namespace API_GruasUCAB.Supplier.Domain.Exceptions
{
     public class InvalidSupplierIdException : DomainException
     {
          public InvalidSupplierIdException()
              : base("Invalid Supplier ID.")
          {
          }
     }
}