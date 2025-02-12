namespace API_GruasUCAB.Users.Domain.ValueObject
{
     public class UserDriverLicenseExpirationDate : ValueObject<UserDriverLicenseExpirationDate>
     {
          public DateTime ExpirationDate { get; }

          public DateTime Value => ExpirationDate;

          public UserDriverLicenseExpirationDate(string expirationDate)
          {
               if (!DateTime.TryParseExact(expirationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
               {
                    throw new InvalidUserDriverLicenseExpirationDateFormatException(expirationDate);
               }

               if (parsedDate < DateTime.UtcNow)
               {
                    throw new InvalidUserDriverLicenseExpirationDateExpiredException(parsedDate);
               }

               if (parsedDate > DateTime.UtcNow.AddYears(10))
               {
                    throw new InvalidUserDriverLicenseExpirationDateTooFarException(parsedDate);
               }

               if (parsedDate < DateTime.UtcNow.AddDays(7))
               {
                    throw new InvalidUserDriverLicenseExpirationDateException(parsedDate);
               }

               ExpirationDate = parsedDate;
          }

          public override bool Equals(UserDriverLicenseExpirationDate other)
          {
               return ExpirationDate == other.ExpirationDate;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return ExpirationDate;
          }

          public override string ToString()
          {
               return ExpirationDate.ToString("dd-MM-yyyy");
          }
     }
}