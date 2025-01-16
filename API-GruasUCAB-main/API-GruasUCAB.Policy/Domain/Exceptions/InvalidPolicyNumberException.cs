namespace API_GruasUCAB.Policy.Domain.Exceptions
{
     public class InvalidPolicyNumberException : DomainException
     {
          public InvalidPolicyNumberException()
              : base("Invalid policy number")
          {
          }
     }
}