namespace API_GruasUCAB.ServiceOrder.Domain.AggregateRoot
{
     public partial class ServiceOrder
     {
          public void SetState(IServiceOrderState state)
          {
               _state = state;
               _state.SetContext(this);
          }

          public void ChangeState(string newState)
          {
               switch (newState)
               {
                    case "PorAceptado":
                         _state.PorAceptado();
                         break;
                    case "Aceptado":
                         _state.Aceptado();
                         break;
                    case "Cancelado":
                         _state.Cancelado();
                         break;
                    case "Localizado":
                         _state.Localizado();
                         break;
                    case "CanceladoPorCobrar":
                         _state.CanceladoPorCobrar();
                         break;
                    case "EnProceso":
                         _state.EnProceso();
                         break;
                    case "Finalizado":
                         _state.Finalizado();
                         break;
                    case "Pagado":
                         _state.Pagado();
                         break;
                    default:
                         throw new InvalidStatusServiceOrderException();
               }
          }

          // Métodos públicos para cambiar las propiedades
          public void UpdateIncidentDescription(IncidentDescription newDescription)
          {
               IncidentDescription = newDescription ?? throw new ArgumentNullException(nameof(newDescription));
               AddDomainEvent(new IncidentDescriptionChangedEvent(Id, newDescription));
          }

          public void UpdateInitialLocationDriver(Coordinates newLocation)
          {
               InitialLocationDriver = newLocation ?? throw new ArgumentNullException(nameof(newLocation));
               AddDomainEvent(new InitialLocationDriverChangedEvent(Id, newLocation));
          }

          public void UpdateIncidentLocation(Coordinates newLocation)
          {
               IncidentLocation = newLocation ?? throw new ArgumentNullException(nameof(newLocation));
               AddDomainEvent(new IncidentLocationChangedEvent(Id, newLocation));
          }

          public void UpdateIncidentLocationEnd(Coordinates newLocation)
          {
               IncidentLocationEnd = newLocation ?? throw new ArgumentNullException(nameof(newLocation));
               AddDomainEvent(new IncidentLocationEndChangedEvent(Id, newLocation));
          }

          public void UpdateIncidentDistance(IncidentDistance newDistance)
          {
               IncidentDistance = newDistance ?? throw new ArgumentNullException(nameof(newDistance));
               AddDomainEvent(new IncidentDistanceChangedEvent(Id, newDistance));
          }

          public void UpdateCustomerVehicleDescription(CustomerVehicleDescription newDescription)
          {
               CustomerVehicleDescription = newDescription ?? throw new ArgumentNullException(nameof(newDescription));
               AddDomainEvent(new CustomerVehicleDescriptionChangedEvent(Id, newDescription));
          }

          public void UpdateIncidentCost(IncidentCost newCost)
          {
               IncidentCost = newCost ?? throw new ArgumentNullException(nameof(newCost));
               AddDomainEvent(new IncidentCostChangedEvent(Id, newCost));
          }

          public void UpdatePolicyId(PolicyId newPolicyId)
          {
               PolicyId = newPolicyId ?? throw new ArgumentNullException(nameof(newPolicyId));
               AddDomainEvent(new PolicyIdChangedEvent(Id, newPolicyId));
          }

          public void UpdateStatusServiceOrder(StatusServiceOrder newStatus)
          {
               StatusServiceOrder = newStatus ?? throw new ArgumentNullException(nameof(newStatus));
               AddDomainEvent(new StatusServiceOrderChangedEvent(Id, newStatus));
          }

          public void UpdateIncidentDate(IncidentDate newDate)
          {
               IncidentDate = newDate ?? throw new ArgumentNullException(nameof(newDate));
               AddDomainEvent(new IncidentDateChangedEvent(Id, newDate));
          }

          public void UpdateVehicleId(VehicleId newVehicleId)
          {
               VehicleId = newVehicleId ?? throw new ArgumentNullException(nameof(newVehicleId));
               AddDomainEvent(new VehicleIdChangedEvent(Id, newVehicleId));
          }

          public void UpdateDriverId(UserId newDriverId)
          {
               DriverId = newDriverId ?? throw new ArgumentNullException(nameof(newDriverId));
               AddDomainEvent(new DriverIdChangedEvent(Id, newDriverId));
          }

          public void UpdateCustomerId(UserId newCustomerId)
          {
               CustomerId = newCustomerId ?? throw new ArgumentNullException(nameof(newCustomerId));
               AddDomainEvent(new CustomerIdChangedEvent(Id, newCustomerId));
          }

          public void UpdateOperatorId(UserId newOperatorId)
          {
               OperatorId = newOperatorId ?? throw new ArgumentNullException(nameof(newOperatorId));
               AddDomainEvent(new OperatorIdChangedEvent(Id, newOperatorId));
          }

          public void UpdateServiceFeeId(ServiceFeeId newServiceFeeId)
          {
               ServiceFeeId = newServiceFeeId ?? throw new ArgumentNullException(nameof(newServiceFeeId));
               AddDomainEvent(new ServiceFeeIdChangedEvent(Id, newServiceFeeId));
          }
     }
}