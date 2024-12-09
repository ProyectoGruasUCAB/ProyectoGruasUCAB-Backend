namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserDriverLicenseExpirationDateTooFarException : Exception
     {
          public InvalidUserDriverLicenseExpirationDateTooFarException(DateTime expirationDate)
              : base($"Driver License Expiration Date is too far in the future: {expirationDate:dd-MM-yyyy}")
          {
          }
     }
}