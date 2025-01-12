namespace API_GruasUCAB.ServiceFee.Domain.Exceptions
{
     public class InvalidServiceFeeNameException : Exception
     {
          public InvalidServiceFeeNameException()
              : base("Invalid service fee name")
          {
          }
     }
}