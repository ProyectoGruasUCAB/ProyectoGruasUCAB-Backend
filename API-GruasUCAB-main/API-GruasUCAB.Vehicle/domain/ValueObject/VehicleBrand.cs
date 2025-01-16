namespace API_GruasUCAB.Vehicle.Domain.ValueObject
{
     public class VehicleBrand : ValueObject<VehicleBrand>
     {
          public string Brand { get; }

          public VehicleBrand(string brand)
          {
               if (string.IsNullOrWhiteSpace(brand))
                    throw new InvalidVehicleBrandException();

               Brand = brand;
          }

          public string Value => Brand;

          public override bool Equals(VehicleBrand other)
          {
               return Brand == other.Brand;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Brand;
          }

          public override string ToString()
          {
               return Brand;
          }
     }
}