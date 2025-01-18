namespace API_GruasUCAB.ServiceOrder.Domain.States
{
     public interface IServiceOrderState
     {
          void SetContext(AggregateRoot.ServiceOrder serviceOrder);
          void PorAceptado();
          void Aceptado();
          void Cancelado();
          void Localizado();
          void CanceladoPorCobrar();
          void EnProceso();
          void Finalizado();
          void Pagado();
     }
}