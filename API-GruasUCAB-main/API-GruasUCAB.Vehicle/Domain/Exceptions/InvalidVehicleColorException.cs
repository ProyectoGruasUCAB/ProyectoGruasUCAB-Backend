using API_GruasUCAB.Core.Domain.DomainException;

namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidVehicleColorException : DomainException
     {
          public InvalidVehicleColorException()
              : base("Invalid Vehicle Color")
          {
          }
     }
}