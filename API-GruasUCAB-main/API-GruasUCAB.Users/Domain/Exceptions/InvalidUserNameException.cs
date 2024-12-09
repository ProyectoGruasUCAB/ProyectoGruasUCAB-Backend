namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserNameException : Exception
     {
          public InvalidUserNameException()
              : base("Invalid user name")
          {
          }
     }
}