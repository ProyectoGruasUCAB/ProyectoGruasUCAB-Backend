namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidPolicyIdException : DomainException
     {
          public InvalidPolicyIdException()
              : base("Invalid policy ID")
          {
          }
     }
}