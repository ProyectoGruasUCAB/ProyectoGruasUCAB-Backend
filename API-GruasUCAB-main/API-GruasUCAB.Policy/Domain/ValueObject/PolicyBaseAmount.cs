namespace API_GruasUCAB.Policy.Domain.ValueObject
{
     public class PolicyBaseAmount : ValueObject<PolicyBaseAmount>
     {
          public float BaseAmount { get; }

          public PolicyBaseAmount(float baseAmount)
          {
               if (baseAmount <= 0)
                    throw new InvalidPolicyBaseAmountException();

               BaseAmount = baseAmount;
          }

          public float Value => BaseAmount;

          public override bool Equals(PolicyBaseAmount other)
          {
               return BaseAmount == other.BaseAmount;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return BaseAmount;
          }

          public override string ToString()
          {
               return BaseAmount.ToString();
          }
     }
}