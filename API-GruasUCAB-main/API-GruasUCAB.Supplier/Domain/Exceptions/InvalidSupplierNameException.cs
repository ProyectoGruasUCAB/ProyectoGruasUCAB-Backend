using API_GruasUCAB.Core.Domain.DomainException;

namespace API_GruasUCAB.Supplier.Domain.Exceptions
{
     public class InvalidSupplierNameException : DomainException
     {
          public InvalidSupplierNameException()
              : base("Invalid Supplier name")
          {
          }
     }
}