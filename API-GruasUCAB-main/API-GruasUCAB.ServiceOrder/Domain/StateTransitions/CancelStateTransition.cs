namespace API_GruasUCAB.ServiceOrder.Domain.StateTransitions
{
     public class CancelStateTransition : IStateTransition
     {
          public ServiceOrderStatus State => ServiceOrderStatus.Cancelado;

          public void Apply(StatusServiceOrder statusServiceOrder)
          {
               statusServiceOrder.Cancel();
          }
     }
}