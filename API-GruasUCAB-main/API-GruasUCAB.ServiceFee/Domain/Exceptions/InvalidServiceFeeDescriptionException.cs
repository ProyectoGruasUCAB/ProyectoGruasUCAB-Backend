namespace API_GruasUCAB.ServiceFee.Domain.Exceptions
{
     public class InvalidServiceFeeDescriptionException : DomainException
     {
          public InvalidServiceFeeDescriptionException()
              : base("The service fee description is invalid. It must be between 10 and 100 characters long.")
          {
          }
     }
}