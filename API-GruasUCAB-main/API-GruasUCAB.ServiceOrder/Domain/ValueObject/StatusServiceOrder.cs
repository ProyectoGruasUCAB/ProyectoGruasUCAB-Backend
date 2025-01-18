namespace API_GruasUCAB.ServiceOrder.Domain.ValueObject
{
     public class StatusServiceOrder : ValueObject<StatusServiceOrder>
     {
          public ServiceOrderStatus Status { get; }

          public ServiceOrderStatus Value => Status;

          public StatusServiceOrder(ServiceOrderStatus status)
          {
               Status = status;
          }

          public override bool Equals(StatusServiceOrder other)
          {
               return Status == other.Status;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Status;
          }

          public override string ToString()
          {
               return Status.ToString();
          }
     }

     public enum ServiceOrderStatus
     {
          PorAsignar,
          PorAceptado,
          Aceptado,
          Localizado,
          EnProceso,
          Finalizado,
          Cancelado,
          CanceladoPorCobrar,
          Pagado
     }
}