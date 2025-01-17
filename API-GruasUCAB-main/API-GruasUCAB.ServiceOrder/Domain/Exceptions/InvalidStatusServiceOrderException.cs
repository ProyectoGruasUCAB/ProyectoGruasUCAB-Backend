namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidStatusServiceOrderException : DomainException
     {
          public InvalidStatusServiceOrderException()
              : base("Invalid status service order")
          {
          }
     }
}