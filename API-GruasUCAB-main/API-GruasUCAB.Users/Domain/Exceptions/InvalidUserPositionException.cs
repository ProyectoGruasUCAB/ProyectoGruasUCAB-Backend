namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserPositionException : DomainException
     {
          public InvalidUserPositionException(string position)
              : base($"Invalid user position: {position}")
          {
          }
     }
}