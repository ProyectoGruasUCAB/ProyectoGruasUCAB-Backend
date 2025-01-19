namespace API_GruasUCAB.ServiceOrder.Domain.StateTransitions
{
     public class FinishStateTransition : IStateTransition
     {
          public ServiceOrderStatus State => ServiceOrderStatus.EnProceso;

          public void Apply(StatusServiceOrder statusServiceOrder)
          {
               statusServiceOrder.Finish();
          }
     }
}