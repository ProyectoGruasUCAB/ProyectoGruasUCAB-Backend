namespace API_GruasUCAB.Users.Domain.ValueObject
{
     public class UserMedicalCertificateExpirationDate : ValueObject<UserMedicalCertificateExpirationDate>
     {
          public DateTime ExpirationDate { get; }

          public DateTime Value => ExpirationDate;

          public UserMedicalCertificateExpirationDate(string expirationDate)
          {
               if (!DateTime.TryParseExact(expirationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
               {
                    throw new InvalidUserMedicalCertificateExpirationDateFormatException(expirationDate);
               }

               if (parsedDate < DateTime.UtcNow)
               {
                    throw new InvalidUserMedicalCertificateExpirationDateExpiredException(parsedDate);
               }

               if (parsedDate > DateTime.UtcNow.AddYears(10))
               {
                    throw new InvalidUserMedicalCertificateExpirationDateTooFarException(parsedDate);
               }

               if (parsedDate < DateTime.UtcNow.AddDays(7))
               {
                    throw new InvalidUserMedicalCertificateExpirationDateException(expirationDate);
               }

               ExpirationDate = parsedDate;
          }

          public override bool Equals(UserMedicalCertificateExpirationDate other)
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