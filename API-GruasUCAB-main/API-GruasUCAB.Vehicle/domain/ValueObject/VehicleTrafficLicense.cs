namespace API_GruasUCAB.Vehicle.Domain.ValueObject
{
     public class VehicleTrafficLicense : ValueObject<VehicleTrafficLicense>
     {
          public string License { get; }

          public VehicleTrafficLicense(string license)
          {
               if (string.IsNullOrWhiteSpace(license))
                    throw new InvalidVehicleTrafficLicenseException();

               License = license;
          }

          public string Value => License;

          public override bool Equals(VehicleTrafficLicense other)
          {
               return License == other.License;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return License;
          }

          public override string ToString()
          {
               return License;
          }
     }
}