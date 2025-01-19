namespace API_GruasUCAB.ServiceOrder.Domain.StateTransitions
{
     public class PayStateTransition : IStateTransition
     {
          public ServiceOrderStatus State => ServiceOrderStatus.Finalizado;

          public void Apply(StatusServiceOrder statusServiceOrder)
          {
               statusServiceOrder.Pay();
          }
     }
}