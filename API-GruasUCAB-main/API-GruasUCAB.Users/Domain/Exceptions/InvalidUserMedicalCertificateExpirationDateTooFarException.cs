namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserMedicalCertificateExpirationDateTooFarException : Exception
     {
          public InvalidUserMedicalCertificateExpirationDateTooFarException(DateTime expirationDate)
              : base($"Medical Certificate Expiration Date is too far in the future: {expirationDate:dd-MM-yyyy}")
          {
          }
     }
}