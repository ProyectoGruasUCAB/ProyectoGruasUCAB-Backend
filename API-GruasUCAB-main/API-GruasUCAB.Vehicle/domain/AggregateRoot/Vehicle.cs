namespace API_GruasUCAB.Vehicle.Domain.AggregateRoot
{
     public class Vehicle : AggregateRoot<VehicleId>
     {
          public VehicleCivilLiability CivilLiability { get; private set; }
          public VehicleCivilLiabilityExpirationDate CivilLiabilityExpirationDate { get; private set; }
          public VehicleTrafficLicense TrafficLicense { get; private set; }
          public VehicleLicensePlate LicensePlate { get; private set; }
          public VehicleBrand Brand { get; private set; }
          public VehicleColor Color { get; private set; }
          public VehicleModel Model { get; private set; }
          public VehicleTypeId VehicleTypeId { get; private set; }
          public UserId DriverId { get; private set; }
          public SupplierId SupplierId { get; private set; }

          public Vehicle(
              VehicleId id,
              VehicleCivilLiability civilLiability,
              VehicleCivilLiabilityExpirationDate civilLiabilityExpirationDate,
              VehicleTrafficLicense trafficLicense,
              VehicleLicensePlate licensePlate,
              VehicleBrand brand,
              VehicleColor color,
              VehicleModel model,
              VehicleTypeId vehicleTypeId,
              UserId driverId,
              SupplierId supplierId)
              : base(id)
          {
               CivilLiability = civilLiability ?? throw new ArgumentNullException(nameof(civilLiability), "Vehicle must have a civil liability.");
               CivilLiabilityExpirationDate = civilLiabilityExpirationDate ?? throw new ArgumentNullException(nameof(civilLiabilityExpirationDate), "Vehicle must have a civil liability expiration date.");
               TrafficLicense = trafficLicense ?? throw new ArgumentNullException(nameof(trafficLicense), "Vehicle must have a traffic license.");
               LicensePlate = licensePlate ?? throw new ArgumentNullException(nameof(licensePlate), "Vehicle must have a license plate.");
               Brand = brand ?? throw new ArgumentNullException(nameof(brand), "Vehicle must have a brand.");
               Color = color ?? throw new ArgumentNullException(nameof(color), "Vehicle must have a color.");
               Model = model ?? throw new ArgumentNullException(nameof(model), "Vehicle must have a model.");
               VehicleTypeId = vehicleTypeId ?? throw new ArgumentNullException(nameof(vehicleTypeId), "Vehicle must have a type.");
               DriverId = driverId ?? throw new ArgumentNullException(nameof(driverId), "Vehicle must have a driver.");
               SupplierId = supplierId ?? throw new ArgumentNullException(nameof(supplierId), "Vehicle must have a supplier.");

               ValidateState();
               AddDomainEvent(new VehicleCreatedEvent(id, civilLiability, civilLiabilityExpirationDate, trafficLicense, licensePlate, brand, color, model, vehicleTypeId, driverId, supplierId));
          }

          protected override void ValidateState()
          {
               ValidateCivilLiability();
               ValidateCivilLiabilityExpirationDate();
               ValidateTrafficLicense();
               ValidateLicensePlate();
               ValidateBrand();
               ValidateColor();
               ValidateModel();
               ValidateVehicleTypeId();
               ValidateDriverId();
               ValidateSupplierId();
          }

          private void ValidateCivilLiability()
          {
               if (CivilLiability == null)
                    throw new InvalidVehicleCivilLiabilityException();
          }

          private void ValidateCivilLiabilityExpirationDate()
          {
               if (CivilLiabilityExpirationDate == null)
                    throw new InvalidVehicleCivilLiabilityExpirationDateException();
          }

          private void ValidateTrafficLicense()
          {
               if (TrafficLicense == null)
                    throw new InvalidVehicleTrafficLicenseException();
          }

          private void ValidateLicensePlate()
          {
               if (LicensePlate == null)
                    throw new InvalidVehicleLicensePlateException();
          }

          private void ValidateBrand()
          {
               if (Brand == null)
                    throw new InvalidVehicleBrandException();
          }

          private void ValidateColor()
          {
               if (Color == null)
                    throw new InvalidVehicleColorException();
          }

          private void ValidateModel()
          {
               if (Model == null)
                    throw new InvalidVehicleModelException();
          }

          private void ValidateVehicleTypeId()
          {
               if (VehicleTypeId == null)
                    throw new InvalidVehicleTypeException();
          }

          private void ValidateDriverId()
          {
               if (DriverId == null)
                    throw new InvalidDriverIdException();
          }

          private void ValidateSupplierId()
          {
               if (SupplierId == null)
                    throw new InvalidSupplierIdException();
          }

          public void ChangeCivilLiability(VehicleCivilLiability newCivilLiability)
          {
               if (newCivilLiability == null)
                    throw new ArgumentNullException(nameof(newCivilLiability), "New civil liability cannot be null.");
               CivilLiability = newCivilLiability;
               ValidateState();
               AddDomainEvent(new VehicleCivilLiabilityChangedEvent(Id, newCivilLiability));
          }

          public void ChangeCivilLiabilityExpirationDate(VehicleCivilLiabilityExpirationDate newExpirationDate)
          {
               if (newExpirationDate == null)
                    throw new ArgumentNullException(nameof(newExpirationDate), "New expiration date cannot be null.");
               CivilLiabilityExpirationDate = newExpirationDate;
               ValidateState();
               AddDomainEvent(new VehicleCivilLiabilityExpirationDateChangedEvent(Id, newExpirationDate));
          }

          public void ChangeTrafficLicense(VehicleTrafficLicense newTrafficLicense)
          {
               if (newTrafficLicense == null)
                    throw new ArgumentNullException(nameof(newTrafficLicense), "New traffic license cannot be null.");
               TrafficLicense = newTrafficLicense;
               ValidateState();
               AddDomainEvent(new VehicleTrafficLicenseChangedEvent(Id, newTrafficLicense));
          }

          public void ChangeLicensePlate(VehicleLicensePlate newLicensePlate)
          {
               if (newLicensePlate == null)
                    throw new ArgumentNullException(nameof(newLicensePlate), "New license plate cannot be null.");
               LicensePlate = newLicensePlate;
               ValidateState();
               AddDomainEvent(new VehicleLicensePlateChangedEvent(Id, newLicensePlate));
          }

          public void ChangeBrand(VehicleBrand newBrand)
          {
               if (newBrand == null)
                    throw new ArgumentNullException(nameof(newBrand), "New brand cannot be null.");
               Brand = newBrand;
               ValidateState();
               AddDomainEvent(new VehicleBrandChangedEvent(Id, newBrand));
          }

          public void ChangeColor(VehicleColor newColor)
          {
               if (newColor == null)
                    throw new ArgumentNullException(nameof(newColor), "New color cannot be null.");
               Color = newColor;
               ValidateState();
               AddDomainEvent(new VehicleColorChangedEvent(Id, newColor));
          }

          public void ChangeModel(VehicleModel newModel)
          {
               if (newModel == null)
                    throw new ArgumentNullException(nameof(newModel), "New model cannot be null.");
               Model = newModel;
               ValidateState();
               AddDomainEvent(new VehicleModelChangedEvent(Id, newModel));
          }

          public void ChangeVehicleTypeId(VehicleTypeId newVehicleTypeId)
          {
               if (newVehicleTypeId == null)
                    throw new ArgumentNullException(nameof(newVehicleTypeId), "New vehicle type cannot be null.");
               VehicleTypeId = newVehicleTypeId;
               ValidateState();
               AddDomainEvent(new VehicleTypeChangedEvent(Id, newVehicleTypeId));
          }

          public void ChangeDriverId(UserId newDriverId)
          {
               if (newDriverId == null)
                    throw new ArgumentNullException(nameof(newDriverId), "New user cannot be null.");
               DriverId = newDriverId;
               ValidateState();
               AddDomainEvent(new VehicleDriverChangedEvent(Id, newDriverId));
          }

          public void ChangeSupplierId(SupplierId newSupplierId)
          {
               if (newSupplierId == null)
                    throw new ArgumentNullException(nameof(newSupplierId), "New supplier cannot be null.");
               SupplierId = newSupplierId;
               ValidateState();
               AddDomainEvent(new VehicleSupplierChangedEvent(Id, newSupplierId));
          }
     }
}