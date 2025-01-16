namespace API_GruasUCAB.Policy.Domain.ValueObject
{
     public class PolicyPriceKm : ValueObject<PolicyPriceKm>
     {
          public float PriceKm { get; }

          public PolicyPriceKm(float priceKm)
          {
               if (priceKm <= 0)
                    throw new InvalidPolicyPriceKmException();

               PriceKm = priceKm;
          }

          public float Value => PriceKm;

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