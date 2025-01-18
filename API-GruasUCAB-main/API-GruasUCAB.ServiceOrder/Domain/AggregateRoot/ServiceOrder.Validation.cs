namespace API_GruasUCAB.ServiceOrder.Domain.AggregateRoot
{
     public partial class ServiceOrder
     {
          protected override void ValidateState()
          {
               ValidateIncidentDescription();
               ValidateInitialLocationDriver();
               ValidateIncidentLocation();
               ValidateIncidentLocationEnd();
               ValidateIncidentDistance();
               ValidateCustomerVehicleDescription();
               ValidateIncidentCost();
               ValidatePolicyId();
               ValidateStatusServiceOrder();
               ValidateIncidentDate();
               ValidateVehicleId();
               ValidateDriverId();
               ValidateCustomerId();
               ValidateOperatorId();
               ValidateServiceFeeId();
          }

          private void ValidateIncidentDescription()
          {
               if (IncidentDescription == null)
                    throw new InvalidIncidentDescriptionException();
          }

          private void ValidateInitialLocationDriver()
          {
               if (InitialLocationDriver == null)
                    throw new InvalidCoordinatesException("Initial location driver coordinates are null.");
          }

          private void ValidateIncidentLocation()
          {
               if (IncidentLocation == null)
                    throw new InvalidCoordinatesException("Incident location coordinates are null.");
          }

          private void ValidateIncidentLocationEnd()
          {
               if (IncidentLocationEnd == null)
                    throw new InvalidCoordinatesException("Incident location end coordinates are null.");
          }

          private void ValidateIncidentDistance()
          {
               if (IncidentDistance == null)
                    throw new InvalidIncidentDistanceException();
          }

          private void ValidateCustomerVehicleDescription()
          {
               if (CustomerVehicleDescription == null)
                    throw new InvalidCustomerVehicleDescriptionException();
          }

          private void ValidateIncidentCost()
          {
               if (IncidentCost == null)
                    throw new InvalidIncidentCostException();
          }

          private void ValidatePolicyId()
          {
               if (PolicyId == null)
                    throw new InvalidPolicyIdException();
          }

          private void ValidateStatusServiceOrder()
          {
               if (StatusServiceOrder == null)
                    throw new InvalidStatusServiceOrderException();
          }

          private void ValidateIncidentDate()
          {
               if (IncidentDate == null)
                    throw new InvalidIncidentDateException(DateTime.MinValue);
          }

          private void ValidateVehicleId()
          {
               if (VehicleId == null)
                    throw new InvalidVehicleIdException();
          }

          private void ValidateDriverId()
          {
               if (DriverId == null)
                    throw new InvalidDriverIdException();
          }

          private void ValidateCustomerId()
          {
               if (CustomerId == null)
                    throw new InvalidCustomerIdException();
          }

          private void ValidateOperatorId()
          {
               if (OperatorId == null)
                    throw new InvalidOperatorIdException();
          }

          private void ValidateServiceFeeId()
          {
               if (ServiceFeeId == null)
                    throw new InvalidServiceFeeIdException();
          }
     }
}