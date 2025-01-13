namespace API_GruasUCAB.Vehicle.Domain.ValueObject
{
     public class VehicleLicensePlate : ValueObject<VehicleLicensePlate>
     {
          public string LicensePlate { get; }

          public VehicleLicensePlate(string licensePlate)
          {
               if (string.IsNullOrWhiteSpace(licensePlate))
                    throw new InvalidVehicleLicensePlateException();

               LicensePlate = licensePlate;
          }

          public string Value => LicensePlate;

          public override bool Equals(VehicleLicensePlate other)
          {
               return LicensePlate == other.LicensePlate;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return LicensePlate;
          }

          public override string ToString()
          {
               return LicensePlate;
          }
     }
}