namespace API_GruasUCAB.ServiceOrder.Domain.States
{
     public class PorAsignarState : ServiceOrderStateBase
     {
          public override void PorAceptado()
          {
               if (_serviceOrder == null)
                    throw new InvalidOperationException("Service order context is not set.");

               _serviceOrder.SetState(new PorAceptadoState());
          }
     }
}