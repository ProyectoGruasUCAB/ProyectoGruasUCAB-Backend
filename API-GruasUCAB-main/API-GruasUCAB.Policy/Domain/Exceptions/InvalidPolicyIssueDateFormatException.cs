namespace API_GruasUCAB.Policy.Domain.Exceptions
{
     public class InvalidPolicyIssueDateFormatException : DomainException
     {
          public InvalidPolicyIssueDateFormatException(string issueDate)
              : base($"Invalid policy issue date format: {issueDate}")
          {
          }
     }
}