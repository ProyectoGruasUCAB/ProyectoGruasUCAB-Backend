namespace API_GruasUCAB.Users.Domain.ValueObject
{
     public class UserId : ValueObject<UserId>
     {
          public string Id { get; }

          public UserId(string id)
          {
               if (!IsValid(id))
                    throw new InvalidUserIdException();

               Id = id;
          }

          public override bool Equals(UserId other)
          {
               return Id == other.Id;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Id;
          }

          private static bool IsValid(string value)
          {
               return Regex.IsMatch(value, @"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$");
          }

          public string Value => Id;

          public override string ToString()
          {
               return Id;
          }
     }
}