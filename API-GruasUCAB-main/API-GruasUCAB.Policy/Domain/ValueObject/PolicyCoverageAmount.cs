namespace API_GruasUCAB.Policy.Domain.ValueObject
{
     public class PolicyCoverageAmount : ValueObject<PolicyCoverageAmount>
     {
          public decimal Amount { get; }

          public PolicyCoverageAmount(decimal amount)
          {
               if (amount <= 0)
                    throw new InvalidPolicyCoverageAmountException();

               Amount = amount;
          }

          public decimal Value => Amount;

          public override bool Equals(PolicyCoverageAmount other)
          {
               return Amount == other.Amount;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Amount;
          }

          public override string ToString()
          {
               return Amount.ToString();
          }
     }
}