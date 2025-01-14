namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserMedicalCertificateExpirationDateFormatException : DomainException
     {
          public InvalidUserMedicalCertificateExpirationDateFormatException(string expirationDate)
              : base($"Invalid Medical Certificate Expiration Date format: {expirationDate}")
          {
          }
     }
}