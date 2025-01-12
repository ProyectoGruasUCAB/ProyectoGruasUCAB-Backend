namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserMedicalCertificateExpirationDateExpiredException : Exception
     {
          public InvalidUserMedicalCertificateExpirationDateExpiredException(DateTime expirationDate)
              : base($"Medical Certificate is expired: {expirationDate:dd-MM-yyyy}")
          {
          }
     }
}