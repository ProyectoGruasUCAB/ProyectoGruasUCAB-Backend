namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidSupplierIdException : DomainException
     {
          public InvalidSupplierIdException()
              : base("Invalid supplier ID")
          {
          }
     }
}