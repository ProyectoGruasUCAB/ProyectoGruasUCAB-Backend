namespace API_GruasUCAB.ServiceOrder.Domain.StateTransitions
{
     public class CancelForChargeStateTransition : IStateTransition
     {
          public ServiceOrderStatus State => ServiceOrderStatus.CanceladoPorCobrar;

          public void Apply(StatusServiceOrder statusServiceOrder)
          {
               statusServiceOrder.CancelForCharge();
          }
     }
}