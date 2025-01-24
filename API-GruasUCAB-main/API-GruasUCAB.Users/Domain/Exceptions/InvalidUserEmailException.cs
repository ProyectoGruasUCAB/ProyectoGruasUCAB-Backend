namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserEmailException : DomainException
     {
          public InvalidUserEmailException()
              : base("Invalid user email")
          {
          }
     }
}