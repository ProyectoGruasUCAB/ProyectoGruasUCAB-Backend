namespace API_GruasUCAB.ServiceFee.Domain.Exceptions
{
     public class InvalidServiceFeeIdException : Exception
     {
          public InvalidServiceFeeIdException()
              : base("Invalid service fee ID")
          {
          }
     }
}