namespace API_GruasUCAB.ServiceFee.Domain.AggregateRoot
{
     public class ServiceFee : AggregateRoot<ServiceFeeId>
     {
          public ServiceFeeName Name { get; private set; }
          public ServiceFeePrice Price { get; private set; }
          public ServiceFeePriceKm PriceKm { get; private set; }
          public ServiceFeeRadius Radius { get; private set; }
          public ServiceFeeDescription Description { get; private set; }

          public ServiceFee(ServiceFeeId id, ServiceFeeName name, ServiceFeePrice price, ServiceFeePriceKm priceKm, ServiceFeeRadius radius, ServiceFeeDescription description)
              : base(id)
          {
               Name = name ?? throw new ArgumentNullException(nameof(name), "Service fee must have a name.");
               Price = price ?? throw new ArgumentNullException(nameof(price), "Service fee must have a price.");
               PriceKm = priceKm ?? throw new ArgumentNullException(nameof(priceKm), "Service fee must have a price per km.");
               Radius = radius ?? throw new ArgumentNullException(nameof(radius), "Service fee must have a radius.");
               Description = description ?? throw new ArgumentNullException(nameof(description), "Service fee must have a description.");

               ValidateState();
               AddDomainEvent(new ServiceFeeCreatedEvent(id, name, price, priceKm, radius, description));
          }

          protected override void ValidateState()
          {
               ValidateName();
               ValidatePrice();
               ValidatePriceKm();
               ValidateRadius();
               ValidateDescription();
          }

          private void ValidateName()
          {
               if (Name == null)
                    throw new InvalidServiceFeeNameException();
          }

          private void ValidatePrice()
          {
               if (Price == null)
                    throw new InvalidServiceFeePriceException();
          }

          private void ValidatePriceKm()
          {
               if (PriceKm == null)
                    throw new InvalidServiceFeePriceKmException();
          }

          private void ValidateRadius()
          {
               if (Radius == null)
                    throw new InvalidServiceFeeRadiusException();
          }

          private void ValidateDescription()
          {
               if (Description == null)
                    throw new InvalidServiceFeeDescriptionException();
          }

          public void ChangeName(ServiceFeeName newName)
          {
               if (newName == null)
                    throw new ArgumentNullException(nameof(newName), "New name cannot be null.");
               Name = newName;
               ValidateState();
               AddDomainEvent(new ServiceFeeNameChangedEvent(Id, newName));
          }

          public void ChangePrice(ServiceFeePrice newPrice)
          {
               if (newPrice == null)
                    throw new ArgumentNullException(nameof(newPrice), "New price cannot be null.");
               Price = newPrice;
               ValidateState();
               AddDomainEvent(new ServiceFeePriceChangedEvent(Id, newPrice));
          }

          public void ChangePriceKm(ServiceFeePriceKm newPriceKm)
          {
               if (newPriceKm == null)
                    throw new ArgumentNullException(nameof(newPriceKm), "New price per km cannot be null.");
               PriceKm = newPriceKm;
               ValidateState();
               AddDomainEvent(new ServiceFeePriceKmChangedEvent(Id, newPriceKm));
          }

          public void ChangeRadius(ServiceFeeRadius newRadius)
          {
               if (newRadius == null)
                    throw new ArgumentNullException(nameof(newRadius), "New radius cannot be null.");
               Radius = newRadius;
               ValidateState();
               AddDomainEvent(new ServiceFeeRadiusChangedEvent(Id, newRadius));
          }

          public void ChangeDescription(ServiceFeeDescription newDescription)
          {
               if (newDescription == null)
                    throw new ArgumentNullException(nameof(newDescription), "New description cannot be null.");
               Description = newDescription;
               ValidateState();
               AddDomainEvent(new ServiceFeeDescriptionChangedEvent(Id, newDescription));
          }
     }
}