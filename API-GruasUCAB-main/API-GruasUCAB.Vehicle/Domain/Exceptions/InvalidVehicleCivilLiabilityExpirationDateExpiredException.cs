namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidVehicleCivilLiabilityExpirationDateExpiredException : DomainException
     {
          public InvalidVehicleCivilLiabilityExpirationDateExpiredException(DateTime expirationDate)
              : base($"Vehicle Civil Liability Expiration Date is expired: {expirationDate:dd-MM-yyyy}")
          {
          }
     }
}