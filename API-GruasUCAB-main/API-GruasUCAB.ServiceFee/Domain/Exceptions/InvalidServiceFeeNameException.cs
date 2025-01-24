namespace API_GruasUCAB.ServiceFee.Domain.Exceptions
{
     public class InvalidServiceFeeNameException : DomainException
     {
          public InvalidServiceFeeNameException()
              : base("Invalid service fee name")
          {
          }
     }
}