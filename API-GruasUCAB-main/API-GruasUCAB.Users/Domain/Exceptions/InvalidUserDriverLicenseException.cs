namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserDriverLicenseException : DomainException
     {
          public InvalidUserDriverLicenseException(string license)
              : base($"Invalid driver license: {license}")
          {
          }
     }
}