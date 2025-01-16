namespace API_GruasUCAB.Policy.Domain.ValueObject
{
     public class PolicyCoverageAmount : ValueObject<PolicyCoverageAmount>
     {
          public float Amount { get; }

          public PolicyCoverageAmount(float amount)
          {
               if (amount <= 0)
                    throw new InvalidPolicyCoverageAmountException();

               Amount = amount;
          }

          public float Value => Amount;

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