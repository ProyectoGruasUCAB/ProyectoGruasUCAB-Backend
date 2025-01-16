namespace API_GruasUCAB.Vehicle.Domain.Exceptions
{
     public class InvalidDriverIdException : DomainException
     {
          public InvalidDriverIdException()
              : base("Invalid User ID")
          {
          }
     }
}