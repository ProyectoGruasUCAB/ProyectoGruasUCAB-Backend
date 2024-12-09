namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserCedulaException : Exception
     {
          public InvalidUserCedulaException(string cedula)
              : base($"Invalid cédula: {cedula}")
          {
          }
     }
}