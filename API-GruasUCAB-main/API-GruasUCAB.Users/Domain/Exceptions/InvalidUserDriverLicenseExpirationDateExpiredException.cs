namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserDriverLicenseExpirationDateExpiredException : DomainException
     {
          public InvalidUserDriverLicenseExpirationDateExpiredException(DateTime expirationDate)
              : base($"Driver License is expired: {expirationDate:dd-MM-yyyy}")
          {
          }
     }
}