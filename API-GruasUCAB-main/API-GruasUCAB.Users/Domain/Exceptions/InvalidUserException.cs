namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserException : DomainException
     {
          public InvalidUserException(string message)
              : base(message)
          {
          }
     }
}