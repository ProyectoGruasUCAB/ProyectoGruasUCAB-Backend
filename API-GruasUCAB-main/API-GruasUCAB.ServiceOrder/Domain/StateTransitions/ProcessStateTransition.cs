namespace API_GruasUCAB.ServiceOrder.Domain.StateTransitions
{
     public class ProcessStateTransition : IStateTransition
     {
          public ServiceOrderStatus State => ServiceOrderStatus.Localizado;

          public void Apply(StatusServiceOrder statusServiceOrder)
          {
               statusServiceOrder.Process();
          }
     }
}