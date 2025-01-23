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