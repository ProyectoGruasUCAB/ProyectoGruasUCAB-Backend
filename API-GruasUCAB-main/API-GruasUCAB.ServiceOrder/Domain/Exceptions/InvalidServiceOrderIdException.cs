namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidServiceOrderIdException : DomainException
     {
          public InvalidServiceOrderIdException()
              : base("Invalid service order ID")
          {
          }
     }
}