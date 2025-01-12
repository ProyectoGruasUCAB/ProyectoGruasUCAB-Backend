namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserCedulaExpirationDateFormatException : Exception
     {
          public InvalidUserCedulaExpirationDateFormatException(string expirationDate)
              : base($"Invalid Cedula Expiration Date format: {expirationDate}")
          {
          }
     }
}