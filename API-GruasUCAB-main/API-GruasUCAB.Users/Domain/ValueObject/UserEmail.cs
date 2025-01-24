namespace API_GruasUCAB.Users.Domain.ValueObject
{
     public class UserEmail : ValueObject<UserEmail>
     {
          public string Email { get; }

          public string Value => Email;

          public UserEmail(string email)
          {
               if (!IsValid(email))
                    throw new InvalidUserEmailException();

               Email = email;
          }

          public override bool Equals(UserEmail other)
          {
               return Email == other.Email;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Email;
          }

          private static bool IsValid(string value)
          {
               return Regex.IsMatch(value, @"^[^\s@]+@[^\s@]+\.[^\s@]+$");
          }

          public override string ToString()
          {
               return Email;
          }
     }
}