namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserCedulaExpirationDateTooFarException : DomainException
     {
          public InvalidUserCedulaExpirationDateTooFarException(DateTime expirationDate)
              : base($"Cedula Expiration Date is too far in the future: {expirationDate:dd-MM-yyyy}")
          {
          }
     }
}