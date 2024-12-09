namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserIdException : Exception
     {
          public InvalidUserIdException()
              : base("Invalid user ID")
          {
          }
     }
}