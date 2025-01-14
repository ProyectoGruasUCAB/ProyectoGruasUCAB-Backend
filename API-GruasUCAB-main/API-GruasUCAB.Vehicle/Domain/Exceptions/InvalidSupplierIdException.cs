namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidSupplierIdException : DomainException
     {
          public InvalidSupplierIdException()
              : base("Invalid Supplier ID")
          {
          }
     }
}