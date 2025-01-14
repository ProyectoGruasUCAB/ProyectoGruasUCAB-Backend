namespace API_GruasUCAB.ServiceFee.Domain.Exceptions
{
     public class InvalidServiceFeePriceKmException : DomainException
     {
          public InvalidServiceFeePriceKmException()
              : base("Invalid service fee price per km")
          {
          }
     }
}