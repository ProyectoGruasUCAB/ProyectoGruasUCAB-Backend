namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidCustomerIdException : DomainException
     {
          public InvalidCustomerIdException()
              : base("Invalid customer ID")
          {
          }
     }
}