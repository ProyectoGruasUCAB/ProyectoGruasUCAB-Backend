namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidDriverIdException : DomainException
     {
          public InvalidDriverIdException()
              : base("Invalid driver ID")
          {
          }
     }
}