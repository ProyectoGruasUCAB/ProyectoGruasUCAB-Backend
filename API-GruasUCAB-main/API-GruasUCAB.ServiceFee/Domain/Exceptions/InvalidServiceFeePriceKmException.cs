namespace API_GruasUCAB.ServiceFee.Domain.Exceptions
{
     public class InvalidServiceFeePriceKmException : Exception
     {
          public InvalidServiceFeePriceKmException()
              : base("Invalid service fee price per km")
          {
          }
     }
}