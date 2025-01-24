namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserMedicalCertificateException : DomainException
     {
          public InvalidUserMedicalCertificateException(string certificate)
              : base($"Invalid medical certificate: {certificate}")
          {
          }
     }
}