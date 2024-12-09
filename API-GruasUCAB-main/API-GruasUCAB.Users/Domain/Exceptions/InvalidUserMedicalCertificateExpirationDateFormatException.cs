namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserMedicalCertificateExpirationDateFormatException : Exception
     {
          public InvalidUserMedicalCertificateExpirationDateFormatException(string expirationDate)
              : base($"Invalid Medical Certificate Expiration Date format: {expirationDate}")
          {
          }
     }
}