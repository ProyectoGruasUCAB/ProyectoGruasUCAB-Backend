namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserMedicalCertificateException : Exception
     {
          public InvalidUserMedicalCertificateException(string certificate)
              : base($"Invalid medical certificate: {certificate}")
          {
          }
     }
}