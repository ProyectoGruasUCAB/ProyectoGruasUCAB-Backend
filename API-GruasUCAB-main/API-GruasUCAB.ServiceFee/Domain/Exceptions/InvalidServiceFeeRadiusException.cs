namespace API_GruasUCAB.ServiceFee.Domain.Exceptions
{
     public class InvalidServiceFeeRadiusException : DomainException
     {
          public InvalidServiceFeeRadiusException()
              : base("Invalid service fee radius")
          {
          }
     }
}