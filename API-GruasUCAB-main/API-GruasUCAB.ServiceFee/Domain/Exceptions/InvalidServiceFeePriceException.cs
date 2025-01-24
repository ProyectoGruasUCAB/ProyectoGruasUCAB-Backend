namespace API_GruasUCAB.ServiceFee.Domain.Exceptions
{
     public class InvalidServiceFeePriceException : DomainException
     {
          public InvalidServiceFeePriceException()
              : base("Invalid service fee price")
          {
          }
     }
}