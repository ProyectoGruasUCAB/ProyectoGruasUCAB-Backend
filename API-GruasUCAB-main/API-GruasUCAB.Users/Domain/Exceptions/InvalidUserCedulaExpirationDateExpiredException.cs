namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserCedulaExpirationDateExpiredException : Exception
     {
          public InvalidUserCedulaExpirationDateExpiredException(DateTime expirationDate)
              : base($"Cedula is  expired: {expirationDate:dd-MM-yyyy}")
          {
          }
     }
}