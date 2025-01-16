namespace API_GruasUCAB.Policy.Domain.Exceptions
{
     public class InvalidPolicyBaseAmountException : DomainException
     {
          public InvalidPolicyBaseAmountException()
              : base("Invalid policy base amount")
          {
          }
     }
}