namespace API_GruasUCAB.Users.Application.Exceptions
{
     public class UserNotFoundException : Exception
     {
          public UserNotFoundException(Guid userId)
              : base($"User with ID {userId} not found.")
          {
          }
     }
}