namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidIncidentDistanceException : DomainException
     {
          public InvalidIncidentDistanceException()
              : base("Invalid incident distance")
          {
          }
     }
}