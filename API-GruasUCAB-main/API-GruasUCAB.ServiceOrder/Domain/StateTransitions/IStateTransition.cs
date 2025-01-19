namespace API_GruasUCAB.ServiceOrder.Domain.StateTransitions
{
     public interface IStateTransition
     {
          ServiceOrderStatus State { get; }
          void Apply(StatusServiceOrder statusServiceOrder);
     }
}