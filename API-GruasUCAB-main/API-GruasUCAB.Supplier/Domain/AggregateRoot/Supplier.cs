namespace API_GruasUCAB.Supplier.Domain.AggregateRoot
{
     public class Supplier : AggregateRoot<SupplierId>
     {
          public SupplierName Name { get; private set; }
          public SupplierType Type { get; private set; }

          public Supplier(SupplierId id, SupplierName name, SupplierType type)
              : base(id)
          {
               Name = name ?? throw new ArgumentNullException(nameof(name), "Supplier must have a name.");
               Type = type ?? throw new ArgumentNullException(nameof(type), "Supplier must have a type.");

               ValidateState();
               AddDomainEvent(new SupplierCreatedEvent(id, name, type));
          }

          protected override void ValidateState()
          {
               ValidateName();
               ValidateType();
          }

          private void ValidateName()
          {
               if (Name == null)
                    throw new InvalidSupplierNameException();
          }

          private void ValidateType()
          {
               if (Type == null)
                    throw new InvalidSupplierTypeException();
          }

          public void ChangeName(SupplierName newName)
          {
               if (newName == null)
                    throw new ArgumentNullException(nameof(newName), "New name cannot be null.");
               Name = newName;
               ValidateState();
               AddDomainEvent(new SupplierNameChangedEvent(Id, newName));
          }

          public void ChangeType(SupplierType newType)
          {
               if (newType == null)
                    throw new ArgumentNullException(nameof(newType), "New type cannot be null.");
               Type = newType;
               ValidateState();
               AddDomainEvent(new SupplierTypeChangedEvent(Id, newType));
          }
     }
}