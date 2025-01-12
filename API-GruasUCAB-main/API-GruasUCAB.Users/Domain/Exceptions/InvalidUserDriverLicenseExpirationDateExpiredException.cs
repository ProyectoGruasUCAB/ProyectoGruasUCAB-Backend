namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserDriverLicenseExpirationDateExpiredException : Exception
     {
          public InvalidUserDriverLicenseExpirationDateExpiredException(DateTime expirationDate)
              : base($"Driver License is expired: {expirationDate:dd-MM-yyyy}")
          {
          }
     }
}