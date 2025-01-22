namespace API_GruasUCAB.Policy.Domain.ValueObject
{
     public class PolicyPriceKm : ValueObject<PolicyPriceKm>
     {
          public decimal PriceKm { get; }

          public PolicyPriceKm(decimal priceKm)
          {
               if (priceKm <= 0)
                    throw new InvalidPolicyPriceKmException();

               PriceKm = priceKm;
          }

          public decimal Value => PriceKm;

          public override bool Equals(PolicyPriceKm other)
          {
               return PriceKm == other.PriceKm;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return PriceKm;
          }

          public override string ToString()
          {
               return PriceKm.ToString();
          }
     }
}