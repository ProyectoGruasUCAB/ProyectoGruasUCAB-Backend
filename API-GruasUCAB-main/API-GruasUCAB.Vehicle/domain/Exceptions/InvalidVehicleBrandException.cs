namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidVehicleBrandException : DomainException
     {
          public InvalidVehicleBrandException()
              : base("Invalid Vehicle Brand")
          {
          }
     }
}