namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserMedicalCertificateExpirationDateException : DomainException
     {
          public InvalidUserMedicalCertificateExpirationDateException(string expirationDate)
              : base($"Invalid Driver License Expiration Date format: {expirationDate}")
          {
          }
     }
}