namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidIncidentCostException : DomainException
     {
          public InvalidIncidentCostException()
              : base("Invalid incident cost")
          {
          }
     }
}