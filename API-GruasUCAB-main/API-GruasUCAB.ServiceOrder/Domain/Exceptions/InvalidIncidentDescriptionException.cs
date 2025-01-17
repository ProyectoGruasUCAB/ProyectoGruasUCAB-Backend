namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidIncidentDescriptionException : DomainException
     {
          public InvalidIncidentDescriptionException()
              : base("Invalid incident description")
          {
          }
     }
}