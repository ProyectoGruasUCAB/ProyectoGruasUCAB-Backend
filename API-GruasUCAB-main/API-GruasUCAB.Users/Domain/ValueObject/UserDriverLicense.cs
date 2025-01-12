namespace API_GruasUCAB.Users.Domain.ValueObject
{
     public class UserDriverLicense : ValueObject<UserDriverLicense>
     {
          public string License { get; }

          public UserDriverLicense(string license)
          {
               if (string.IsNullOrWhiteSpace(license))
                    throw new InvalidUserDriverLicenseException(license);

               License = license;
          }

          public override bool Equals(UserDriverLicense other)
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