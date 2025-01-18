namespace API_GruasUCAB.ServiceOrder.Domain.States
{
     public abstract class ServiceOrderStateBase : IServiceOrderState
     {
          protected AggregateRoot.ServiceOrder? _serviceOrder;

          public void SetContext(AggregateRoot.ServiceOrder serviceOrder)
          {
               _serviceOrder = serviceOrder;
          }

          public virtual void PorAceptado() => throw new InvalidOperationException("Invalid state transition.");
          public virtual void Aceptado() => throw new InvalidOperationException("Invalid state transition.");
          public virtual void Cancelado() => throw new InvalidOperationException("Invalid state transition.");
          public virtual void Localizado() => throw new InvalidOperationException("Invalid state transition.");
          public virtual void CanceladoPorCobrar() => throw new InvalidOperationException("Invalid state transition.");
          public virtual void EnProceso() => throw new InvalidOperationException("Invalid state transition.");
          public virtual void Finalizado() => throw new InvalidOperationException("Invalid state transition.");
          public virtual void Pagado() => throw new InvalidOperationException("Invalid state transition.");
     }
}