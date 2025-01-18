namespace API_GruasUCAB.ServiceOrder.Domain.States
{
     public class FinalizadoState : ServiceOrderStateBase
     {
          public override void Pagado()
          {
               if (_serviceOrder == null)
                    throw new InvalidOperationException("Service order context is not set.");

               _serviceOrder.SetState(new PagadoState());
          }

          public override void Cancelado()
          {
               if (_serviceOrder == null)
                    throw new InvalidOperationException("Service order context is not set.");

               _serviceOrder.SetState(new CanceladoState());
          }
     }
}