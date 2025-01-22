namespace API_GruasUCAB.Policy.Domain.ValueObject
{
     public class PolicyBaseAmount : ValueObject<PolicyBaseAmount>
     {
          public decimal BaseAmount { get; }

          public PolicyBaseAmount(decimal baseAmount)
          {
               if (baseAmount <= 0)
                    throw new InvalidPolicyBaseAmountException();

               BaseAmount = baseAmount;
          }

          public decimal Value => BaseAmount;

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