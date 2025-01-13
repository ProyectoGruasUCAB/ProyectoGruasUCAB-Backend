using API_GruasUCAB.Core.Domain.DomainException;

namespace API_GruasUCAB.Supplier.Domain.Exceptions
{
     public class InvalidSupplierTypeException : DomainException
     {
          public InvalidSupplierTypeException()
              : base("Invalid Supplier Type")
          {
          }
     }
}