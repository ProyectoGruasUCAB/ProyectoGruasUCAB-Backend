namespace API_GruasUCAB.Users.Domain.ValueObject
{
     public class UserPosition : ValueObject<UserPosition>
     {
          public string Position { get; }

          public UserPosition(string position)
          {
               if (string.IsNullOrWhiteSpace(position))
                    throw new InvalidUserPositionException(position);

               Position = position;
          }

          public override bool Equals(UserPosition other)
          {
               return Position == other.Position;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Position;
          }

          public override string ToString()
          {
               return Position;
          }
     }
}