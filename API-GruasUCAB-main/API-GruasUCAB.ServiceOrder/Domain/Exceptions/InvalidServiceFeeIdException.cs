namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidServiceFeeIdException : DomainException
     {
          public InvalidServiceFeeIdException()
              : base("Invalid service fee ID")
          {
          }
     }
}