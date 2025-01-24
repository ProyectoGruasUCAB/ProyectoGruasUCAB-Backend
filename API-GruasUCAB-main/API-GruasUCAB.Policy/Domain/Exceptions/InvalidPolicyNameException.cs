namespace API_GruasUCAB.Policy.Domain.Exceptions
{
     public class InvalidPolicyNameException : DomainException
     {
          public InvalidPolicyNameException()
              : base("Invalid policy name")
          {
          }
     }
}