namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserCedulaExpirationDateExpiredException : DomainException
     {
          public InvalidUserCedulaExpirationDateExpiredException(DateTime expirationDate)
              : base($"Cedula is  expired: {expirationDate:dd-MM-yyyy}")
          {
          }
     }
}