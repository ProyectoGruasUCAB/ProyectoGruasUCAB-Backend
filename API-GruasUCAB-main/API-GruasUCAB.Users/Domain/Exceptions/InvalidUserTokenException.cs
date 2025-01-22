namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserTokenException : DomainException
     {
          public InvalidUserTokenException(string token)
              : base($"Invalid user token: {token}")
          {
          }
     }
}