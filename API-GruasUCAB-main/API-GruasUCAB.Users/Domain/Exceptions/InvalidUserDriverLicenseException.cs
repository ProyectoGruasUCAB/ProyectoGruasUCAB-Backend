namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserDriverLicenseException : Exception
     {
          public InvalidUserDriverLicenseException(string license)
              : base($"Invalid driver license: {license}")
          {
          }
     }
}