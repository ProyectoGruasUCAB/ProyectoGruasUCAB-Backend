namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidVehicleCivilLiabilityException : DomainException
     {
          public InvalidVehicleCivilLiabilityException()
              : base("Invalid Vehicle Civil Liability")
          {
          }
     }
}