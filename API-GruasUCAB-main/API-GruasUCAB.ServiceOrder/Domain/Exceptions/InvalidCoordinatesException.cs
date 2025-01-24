namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidCoordinatesException : DomainException
     {
          public InvalidCoordinatesException(string message)
              : base(message)
          {
          }
     }
}