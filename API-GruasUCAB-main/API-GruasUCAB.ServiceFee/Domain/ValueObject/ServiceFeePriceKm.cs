namespace API_GruasUCAB.ServiceFee.Domain.ValueObject
{
     public class ServiceFeePriceKm : ValueObject<ServiceFeePriceKm>
     {
          public float PriceKm { get; }

          public ServiceFeePriceKm(float priceKm)
          {
               if (priceKm <= 0)
                    throw new InvalidServiceFeePriceKmException();

               PriceKm = priceKm;
          }

          public float Value => PriceKm;

          public override bool Equals(ServiceFeePriceKm other)
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