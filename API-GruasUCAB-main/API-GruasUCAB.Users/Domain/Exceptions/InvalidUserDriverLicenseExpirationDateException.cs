namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserDriverLicenseExpirationDateException : DomainException
     {
          public InvalidUserDriverLicenseExpirationDateException(DateTime license)
              : base($"Invalid Driver License Expiration Date: {license.ToString("dd-MM-yyyy")}")
          {
          }
     }
}