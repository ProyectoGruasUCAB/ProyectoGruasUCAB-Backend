namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserDriverLicenseExpirationDateException : Exception
     {
          public InvalidUserDriverLicenseExpirationDateException(DateTime license)
              : base($"Invalid Driver License Expiration Date: {license.ToString("dd-MM-yyyy")}")
          {
          }
     }
}