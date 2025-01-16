namespace API_GruasUCAB.Policy.Domain.Exceptions
{
     public class InvalidPolicyCoverageAmountException : DomainException
     {
          public InvalidPolicyCoverageAmountException()
              : base("Invalid policy coverage amount")
          {
          }
     }
}