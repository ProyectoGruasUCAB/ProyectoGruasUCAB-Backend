namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidVehicleModelException : DomainException
     {
          public InvalidVehicleModelException()
              : base("Invalid Vehicle Model")
          {
          }
     }
}