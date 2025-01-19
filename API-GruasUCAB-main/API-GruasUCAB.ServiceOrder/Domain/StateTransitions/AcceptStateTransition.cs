namespace API_GruasUCAB.ServiceOrder.Domain.StateTransitions
{
     public class AcceptStateTransition : IStateTransition
     {
          public ServiceOrderStatus State => ServiceOrderStatus.PorAceptado;

          public void Apply(StatusServiceOrder statusServiceOrder)
          {
               statusServiceOrder.Accept();
          }
     }
}