namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidVehicleCivilLiabilityExpirationDateFormatException : Exception
     {
          public InvalidVehicleCivilLiabilityExpirationDateFormatException(string expirationDate)
              : base($"Invalid Vehicle Civil Liability Expiration Date format: {expirationDate}")
          {
          }
     }
}