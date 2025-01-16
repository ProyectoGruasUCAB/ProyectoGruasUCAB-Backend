namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidVehicleTypeException : DomainException
     {
          public InvalidVehicleTypeException()
              : base("Invalid Vehicle Type")
          {
          }
     }
}