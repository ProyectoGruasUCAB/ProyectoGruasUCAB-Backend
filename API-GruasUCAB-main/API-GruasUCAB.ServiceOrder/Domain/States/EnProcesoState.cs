namespace API_GruasUCAB.ServiceOrder.Domain.States
{
     public class EnProcesoState : ServiceOrderStateBase
     {
          public override void Finalizado()
          {
               if (_serviceOrder == null)
                    throw new InvalidOperationException("Service order context is not set.");

               _serviceOrder.SetState(new FinalizadoState());
          }

          public override void Cancelado()
          {
               if (_serviceOrder == null)
                    throw new InvalidOperationException("Service order context is not set.");

               _serviceOrder.SetState(new CanceladoState());
          }
     }
}