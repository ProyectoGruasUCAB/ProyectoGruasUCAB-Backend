namespace API_GruasUCAB.ServiceOrder.Domain.States
{
     public class PorAceptadoState : ServiceOrderStateBase
     {
          public override void Aceptado()
          {
               if (_serviceOrder == null)
                    throw new InvalidOperationException("Service order context is not set.");

               _serviceOrder.SetState(new AceptadoState());
          }

          public override void Cancelado()
          {
               if (_serviceOrder == null)
                    throw new InvalidOperationException("Service order context is not set.");

               _serviceOrder.SetState(new CanceladoState());
          }
     }
}