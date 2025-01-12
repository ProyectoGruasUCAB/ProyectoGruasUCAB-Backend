namespace API_GruasUCAB.Users.Domain.ValueObject
{
     public class UserCedulaExpirationDate : ValueObject<UserCedulaExpirationDate>
     {
          public DateTime ExpirationDate { get; }

          public UserCedulaExpirationDate(string expirationDate)
          {
               if (!DateTime.TryParseExact(expirationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
               {
                    throw new InvalidUserCedulaExpirationDateFormatException(expirationDate);
               }

               if (parsedDate < DateTime.UtcNow)
               {
                    throw new InvalidUserCedulaExpirationDateExpiredException(parsedDate);
               }

               if (parsedDate > DateTime.UtcNow.AddYears(10))
               {
                    throw new InvalidUserCedulaExpirationDateTooFarException(parsedDate);
               }

               ExpirationDate = parsedDate;
          }

          public override bool Equals(UserCedulaExpirationDate other)
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