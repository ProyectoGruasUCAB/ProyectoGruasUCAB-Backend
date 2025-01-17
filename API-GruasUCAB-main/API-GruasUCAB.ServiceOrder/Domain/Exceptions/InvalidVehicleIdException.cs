namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidVehicleIdException : DomainException
     {
          public InvalidVehicleIdException()
              : base("Invalid vehicle ID")
          {
          }
     }
}