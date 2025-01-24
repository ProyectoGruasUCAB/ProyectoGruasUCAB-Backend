namespace API_GruasUCAB.Policy.Domain.Exceptions
{
     public class InvalidPolicyCoverageKmException : DomainException
     {
          public InvalidPolicyCoverageKmException()
              : base("Invalid policy coverage kilometers")
          {
          }
     }
}