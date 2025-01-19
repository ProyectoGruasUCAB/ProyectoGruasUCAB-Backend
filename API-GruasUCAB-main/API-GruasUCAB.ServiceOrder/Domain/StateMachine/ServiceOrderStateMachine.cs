namespace API_GruasUCAB.ServiceOrder.Domain.StateMachine
{
    public class ServiceOrderStateMachine
    {
        private readonly StateMachine<ServiceOrderStatus, Trigger> _machine;

        public ServiceOrderStateMachine(ServiceOrderStatus initialState)
        {
            _machine = new StateMachine<ServiceOrderStatus, Trigger>(initialState);

            _machine.Configure(ServiceOrderStatus.PorAsignar)
                .Permit(Trigger.Assign, ServiceOrderStatus.PorAceptado)
                .Permit(Trigger.Cancel, ServiceOrderStatus.Cancelado);

            _machine.Configure(ServiceOrderStatus.PorAceptado)
                .Permit(Trigger.Accept, ServiceOrderStatus.Aceptado)
                .Permit(Trigger.Cancel, ServiceOrderStatus.Cancelado);

            _machine.Configure(ServiceOrderStatus.Aceptado)
                .Permit(Trigger.Locate, ServiceOrderStatus.Localizado)
                .Permit(Trigger.Cancel, ServiceOrderStatus.Cancelado);

            _machine.Configure(ServiceOrderStatus.Localizado)
                .Permit(Trigger.Process, ServiceOrderStatus.EnProceso)
                .Permit(Trigger.CancelForCharge, ServiceOrderStatus.CanceladoPorCobrar);

            _machine.Configure(ServiceOrderStatus.EnProceso)
                .Permit(Trigger.Finish, ServiceOrderStatus.Finalizado);

            _machine.Configure(ServiceOrderStatus.Finalizado)
                .Permit(Trigger.Pay, ServiceOrderStatus.Pagado);

            _machine.Configure(ServiceOrderStatus.Pagado)
                .PermitReentry(Trigger.Pay); // No permite transiciones a otros estados
        }

        public ServiceOrderStatus State => _machine.State;

        public void Fire(Trigger trigger)
        {
            _machine.Fire(trigger);
        }

        public enum Trigger
        {
            Assign,
            Accept,
            Locate,
            Process,
            Finish,
            Pay,
            Cancel,
            CancelForCharge
        }
    }
}