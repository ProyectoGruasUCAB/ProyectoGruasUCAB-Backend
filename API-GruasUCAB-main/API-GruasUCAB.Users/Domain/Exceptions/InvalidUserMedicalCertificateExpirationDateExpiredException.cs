namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserMedicalCertificateExpirationDateExpiredException : DomainException
     {
          public InvalidUserMedicalCertificateExpirationDateExpiredException(DateTime expirationDate)
              : base($"Medical Certificate is expired: {expirationDate:dd-MM-yyyy}")
          {
          }
     }
}