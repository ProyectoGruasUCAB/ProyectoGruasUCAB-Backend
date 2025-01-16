namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidVehicleTypeIdException : DomainException
     {
          public InvalidVehicleTypeIdException()
              : base("Invalid Vehicle Type ID")
          {
          }
     }
}