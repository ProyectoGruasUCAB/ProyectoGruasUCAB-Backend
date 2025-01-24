namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidCustomerVehicleDescriptionException : DomainException
     {
          public InvalidCustomerVehicleDescriptionException()
              : base("Invalid customer vehicle description")
          {
          }
     }
}