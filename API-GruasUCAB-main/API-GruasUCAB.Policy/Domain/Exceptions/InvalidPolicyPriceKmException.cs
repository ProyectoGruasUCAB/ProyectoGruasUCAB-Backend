namespace API_GruasUCAB.Policy.Domain.Exceptions
{
     public class InvalidPolicyPriceKmException : DomainException
     {
          public InvalidPolicyPriceKmException()
              : base("Invalid policy price per kilometer")
          {
          }
     }
}