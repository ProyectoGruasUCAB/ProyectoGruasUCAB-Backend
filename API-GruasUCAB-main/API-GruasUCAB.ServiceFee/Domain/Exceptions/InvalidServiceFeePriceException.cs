namespace API_GruasUCAB.ServiceFee.Domain.Exceptions
{
     public class InvalidServiceFeePriceException : Exception
     {
          public InvalidServiceFeePriceException()
              : base("Invalid service fee price")
          {
          }
     }
}