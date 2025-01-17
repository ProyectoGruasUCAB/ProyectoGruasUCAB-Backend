namespace API_GruasUCAB.ServiceOrder.Domain.States
{
     public class LocalizadoState : ServiceOrderStateBase
     {
          public override void EnProceso()
          {
               if (_serviceOrder == null)
                    throw new InvalidOperationException("Service order context is not set.");

               _serviceOrder.SetState(new EnProcesoState());
          }

          public override void CanceladoPorCobrar()
          {
               if (_serviceOrder == null)
                    throw new InvalidOperationException("Service order context is not set.");

               _serviceOrder.SetState(new CanceladoPorCobrarState());
          }
     }
}