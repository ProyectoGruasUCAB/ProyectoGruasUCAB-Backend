namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserDriverLicenseExpirationDateFormatException : Exception
     {
          public InvalidUserDriverLicenseExpirationDateFormatException(string expirationDate)
              : base($"Invalid Driver License Expiration Date format: {expirationDate}")
          {
          }
     }
}