using API_GruasUCAB.Core.Domain.DomainException;

namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
    public class InvalidVehicleTrafficLicenseException : DomainException
    {
        public InvalidVehicleTrafficLicenseException()
            : base("Invalid Vehicle Traffic License")
        {
        }
    }
}