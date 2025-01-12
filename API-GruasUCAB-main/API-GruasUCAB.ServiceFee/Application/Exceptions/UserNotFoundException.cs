namespace API_GruasUCAB.ServiceFee.Application.Exceptions
{
     public class ServiceFeeNotFoundException : Exception
     {
          public ServiceFeeNotFoundException(Guid serviceFeeId)
              : base($"Service Fee with ID {serviceFeeId} not found.")
          {
          }
     }
}