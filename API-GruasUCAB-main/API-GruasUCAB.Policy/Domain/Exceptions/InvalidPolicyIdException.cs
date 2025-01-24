namespace API_GruasUCAB.Policy.Domain.Exceptions
{
     public class InvalidPolicyIdException : DomainException
     {
          public InvalidPolicyIdException()
              : base("Invalid policy ID")
          {
          }
     }
}