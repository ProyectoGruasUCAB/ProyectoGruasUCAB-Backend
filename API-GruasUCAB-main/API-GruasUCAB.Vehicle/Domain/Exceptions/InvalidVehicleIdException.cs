using API_GruasUCAB.Core.Domain.DomainException;

namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidVehicleIdException : DomainException
     {
          public InvalidVehicleIdException()
              : base("Invalid Vehicle ID")
          {
          }
     }
}