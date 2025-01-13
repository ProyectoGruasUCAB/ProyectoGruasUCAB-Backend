using API_GruasUCAB.Core.Domain.DomainException;

namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidVehicleCivilLiabilityExpirationDateException : DomainException
     {
          public InvalidVehicleCivilLiabilityExpirationDateException()
              : base("Invalid Vehicle Civil Liability Expiration Date")
          {
          }
     }
}