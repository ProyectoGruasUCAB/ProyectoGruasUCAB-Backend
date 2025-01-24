namespace API_GruasUCAB.ServiceFee.Domain.ValueObject
{
     public class ServiceFeePrice : ValueObject<ServiceFeePrice>
     {
          public float Price { get; }

          public ServiceFeePrice(float price)
          {
               if (price <= 0)
                    throw new InvalidServiceFeePriceException();

               Price = price;
          }

          public float Value => Price;

          public override bool Equals(ServiceFeePrice other)
          {
               return Price == other.Price;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Price;
          }

          public override string ToString()
          {
               return Price.ToString();
          }
     }
}