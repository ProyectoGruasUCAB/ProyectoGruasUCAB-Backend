namespace API_GruasUCAB.Users.Domain.ValueObject
{
     public class UserBirthDate : ValueObject<UserBirthDate>
     {
          public DateTime BirthDate { get; }

          public DateTime Value => BirthDate;

          public UserBirthDate(string birthDate)
          {
               if (!DateTime.TryParseExact(birthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
               {
                    throw new InvalidUserBirthDateException(parsedDate);
               }

               if (parsedDate > DateTime.UtcNow)
                    throw new InvalidUserBirthDateException(parsedDate);

               int minimumAge = 18;
               if (DateUtils.CalculateYearsDifference(parsedDate, DateTime.UtcNow) < minimumAge)
                    throw new InvalidUserBirthDateException(parsedDate);

               BirthDate = parsedDate;
          }

          public override bool Equals(UserBirthDate other)
          {
               return BirthDate == other.BirthDate;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return BirthDate;
          }

          public override string ToString()
          {
               return BirthDate.ToString("dd-MM-yyyy");
          }
     }
}