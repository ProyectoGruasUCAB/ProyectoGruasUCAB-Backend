namespace API_GruasUCAB.ServiceFee.Domain.Exceptions
{
     public class InvalidServiceFeeRadiusException : Exception
     {
          public InvalidServiceFeeRadiusException()
              : base("Invalid service fee radius")
          {
          }
     }
}