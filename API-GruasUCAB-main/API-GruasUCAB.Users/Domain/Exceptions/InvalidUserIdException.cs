namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserIdException : DomainException
     {
          public InvalidUserIdException()
              : base("Invalid user ID...")
          {
          }
     }
}