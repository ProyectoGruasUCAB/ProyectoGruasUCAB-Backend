namespace API_GruasUCAB.ServiceFee.Domain.Exceptions
{
     public class InvalidServiceFeeIdException : DomainException
     {
          public InvalidServiceFeeIdException()
              : base("Invalid service fee ID")
          {
          }
     }
}