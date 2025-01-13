using API_GruasUCAB.Core.Domain.DomainException;

namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidVehicleLicensePlateException : DomainException
     {
          public InvalidVehicleLicensePlateException()
              : base("Invalid Vehicle License Plate")
          {
          }
     }
}