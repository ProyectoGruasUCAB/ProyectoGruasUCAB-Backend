namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidVehicleCivilLiabilityExpirationDateFormatException : DomainException
     {
          public InvalidVehicleCivilLiabilityExpirationDateFormatException(string expirationDate)
              : base($"Invalid Vehicle Civil Liability Expiration Date format: {expirationDate}")
          {
          }
     }
}