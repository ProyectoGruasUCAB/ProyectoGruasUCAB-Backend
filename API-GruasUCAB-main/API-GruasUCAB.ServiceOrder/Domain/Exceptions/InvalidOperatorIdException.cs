namespace API_GruasUCAB.ServiceOrder.Domain.Exceptions
{
     public class InvalidOperatorIdException : DomainException
     {
          public InvalidOperatorIdException()
              : base("Invalid operator ID")
          {
          }
     }
}