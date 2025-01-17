namespace API_GruasUCAB.ServiceOrder.Domain.States
{
     public class AceptadoState : ServiceOrderStateBase
     {
          public override void Localizado()
          {
               if (_serviceOrder == null)
                    throw new InvalidOperationException("Service order context is not set.");

               _serviceOrder.SetState(new LocalizadoState());
          }

          public override void CanceladoPorCobrar()
          {
               if (_serviceOrder == null)
                    throw new InvalidOperationException("Service order context is not set.");

               _serviceOrder.SetState(new CanceladoPorCobrarState());
          }
     }
}