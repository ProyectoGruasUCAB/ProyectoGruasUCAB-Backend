namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidVehicleCivilLiabilityExpirationDateTooFarException : Exception
     {
          public InvalidVehicleCivilLiabilityExpirationDateTooFarException(DateTime expirationDate)
              : base($"Vehicle Civil Liability Expiration Date is too far in the future: {expirationDate:dd-MM-yyyy}")
          {
          }
     }
}