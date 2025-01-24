namespace API_GruasUCAB.Policy.Domain.Exceptions
{
     public class InvalidPolicyExpirationDateException : DomainException
     {
          public InvalidPolicyExpirationDateException(DateTime expirationDate)
              : base($"Policy expiration date must be greater than the issue date: {expirationDate}")
          {
          }
     }
}