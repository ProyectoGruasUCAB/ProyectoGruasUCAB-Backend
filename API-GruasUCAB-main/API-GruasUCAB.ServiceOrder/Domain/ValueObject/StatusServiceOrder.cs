namespace API_GruasUCAB.ServiceOrder.Domain.ValueObject
{
     public class StatusServiceOrder : ValueObject<StatusServiceOrder>
     {
          private readonly ServiceOrderStateMachine _stateMachine;

          public ServiceOrderStatus Status => _stateMachine.State;

          public ServiceOrderStatus Value => Status;

          public StatusServiceOrder(ServiceOrderStatus status)
          {
               _stateMachine = new ServiceOrderStateMachine(status);
          }

          public void Assign()
          {
               _stateMachine.Fire(ServiceOrderStateMachine.Trigger.Assign);
          }

          public void Accept()
          {
               _stateMachine.Fire(ServiceOrderStateMachine.Trigger.Accept);
          }

          public void Locate()
          {
               _stateMachine.Fire(ServiceOrderStateMachine.Trigger.Locate);
          }

          public void Process()
          {
               _stateMachine.Fire(ServiceOrderStateMachine.Trigger.Process);
          }

          public void Finish()
          {
               _stateMachine.Fire(ServiceOrderStateMachine.Trigger.Finish);
          }

          public void Pay()
          {
               _stateMachine.Fire(ServiceOrderStateMachine.Trigger.Pay);
          }

          public void Cancel()
          {
               _stateMachine.Fire(ServiceOrderStateMachine.Trigger.Cancel);
          }

          public void CancelForCharge()
          {
               _stateMachine.Fire(ServiceOrderStateMachine.Trigger.CancelForCharge);
          }

          public override bool Equals(StatusServiceOrder other)
          {
               return Status == other.Status;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Status;
          }

          public override string ToString()
          {
               return Status.ToString();
          }
     }

     public enum ServiceOrderStatus
     {
          PorAsignar,
          PorAceptado,
          Aceptado,
          Localizado,
          EnProceso,
          Finalizado,
          Cancelado,
          CanceladoPorCobrar,
          Pagado
     }
}