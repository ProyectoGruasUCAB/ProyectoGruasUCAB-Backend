namespace API_GruasUCAB.ServiceFee.Domain.ValueObject
{
     public class ServiceFeeRadius : ValueObject<ServiceFeeRadius>
     {
          public int Radius { get; }

          public ServiceFeeRadius(int radius)
          {
               if (radius <= 0)
                    throw new InvalidServiceFeeRadiusException();

               Radius = radius;
          }

          public int Value => Radius;

          public override bool Equals(ServiceFeeRadius other)
          {
               return Radius == other.Radius;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Radius;
          }

          public override string ToString()
          {
               return Radius.ToString();
          }
     }
}