namespace API_GruasUCAB.Policy.Domain.Exceptions
{
     public class InvalidPolicyExpirationDateFormatException : DomainException
     {
          public InvalidPolicyExpirationDateFormatException(string expirationDate)
              : base($"Invalid policy expiration date format: {expirationDate}")
          {
          }
     }
}