namespace API_GruasUCAB.Policy.Domain.Exceptions
{
     public class InvalidPolicyClientIdException : DomainException
     {
          public InvalidPolicyClientIdException()
              : base("Invalid policy client ID")
          {
          }
     }
}