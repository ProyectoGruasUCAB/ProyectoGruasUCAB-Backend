namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class ServiceOrderNotFoundException : DomainException
     {
          public ServiceOrderNotFoundException(Guid id)
              : base($"Service order with ID {id} was not found.")
          {
          }
     }
}