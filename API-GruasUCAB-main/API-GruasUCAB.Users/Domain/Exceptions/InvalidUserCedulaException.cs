namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserCedulaException : DomainException
     {
          public InvalidUserCedulaException(string cedula)
              : base($"Invalid cédula: {cedula}")
          {
          }
     }
}