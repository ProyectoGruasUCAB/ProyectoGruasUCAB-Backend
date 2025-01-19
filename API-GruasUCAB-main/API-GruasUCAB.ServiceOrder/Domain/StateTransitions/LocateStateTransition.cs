namespace API_GruasUCAB.ServiceOrder.Domain.StateTransitions
{
     public class LocateStateTransition : IStateTransition
     {
          public ServiceOrderStatus State => ServiceOrderStatus.Aceptado;

          public void Apply(StatusServiceOrder statusServiceOrder)
          {
               statusServiceOrder.Locate();
          }
     }
}