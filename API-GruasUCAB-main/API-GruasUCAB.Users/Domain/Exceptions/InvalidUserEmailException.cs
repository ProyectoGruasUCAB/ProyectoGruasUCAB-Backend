namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserEmailException : Exception
     {
          public InvalidUserEmailException()
              : base("Invalid user email")
          {
          }
     }
}