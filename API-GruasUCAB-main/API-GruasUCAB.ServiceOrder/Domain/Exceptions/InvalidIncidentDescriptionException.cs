namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidIncidentDescriptionException : Exception
     {
          public InvalidIncidentDescriptionException(string message)
              : base(message)
          {
          }
     }
}