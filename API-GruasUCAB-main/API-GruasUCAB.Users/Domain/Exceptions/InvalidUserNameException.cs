namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserNameException : DomainException
     {
          public InvalidUserNameException()
              : base("Invalid user name")
          {
          }
     }
}