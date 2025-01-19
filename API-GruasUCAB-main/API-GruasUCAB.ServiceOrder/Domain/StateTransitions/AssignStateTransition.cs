namespace API_GruasUCAB.ServiceOrder.Domain.StateTransitions
{
     public class AssignStateTransition : IStateTransition
     {
          public ServiceOrderStatus State => ServiceOrderStatus.PorAsignar;

          public void Apply(StatusServiceOrder statusServiceOrder)
          {
               statusServiceOrder.Assign();
          }
     }
}