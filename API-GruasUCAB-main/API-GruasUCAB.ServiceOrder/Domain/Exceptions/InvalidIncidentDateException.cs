namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidIncidentDateException : DomainException
     {
          public InvalidIncidentDateException(DateTime date)
              : base($"Invalid incident date: {date:dd-MM-yyyy}")
          {
          }
     }
}