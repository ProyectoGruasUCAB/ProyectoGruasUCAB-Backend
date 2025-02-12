namespace API_GruasUCAB.Users.Domain.Entities
{
     public class Provider : AggregateRoot<UserId>
     {
          public UserName Name { get; private set; }
          public UserEmail Email { get; private set; }
          public UserPhone Phone { get; private set; }
          public UserCedula Cedula { get; private set; }
          public UserBirthDate BirthDate { get; private set; }
          public SupplierId SupplierId { get; private set; }

          public Provider(UserId id, UserName name, UserEmail email, UserPhone phone, UserCedula cedula, UserBirthDate birthDate, SupplierId supplierId)
              : base(id)
          {
               Name = name ?? throw new ArgumentNullException(nameof(name), "Provider must have a name.");
               Email = email ?? throw new ArgumentNullException(nameof(email), "Provider must have an email.");
               Phone = phone ?? throw new ArgumentNullException(nameof(phone), "Provider must have a phone.");
               Cedula = cedula ?? throw new ArgumentNullException(nameof(cedula), "Provider must have a cedula.");
               BirthDate = birthDate ?? throw new ArgumentNullException(nameof(birthDate), "Provider must have a birth date.");
               SupplierId = supplierId ?? throw new ArgumentNullException(nameof(supplierId), "Provider must have a supplier.");

               ValidateState();
               AddDomainEvent(new RecordProviderDataEvent(id, name, email, phone, birthDate, supplierId));
          }

          protected override void ValidateState()
          {
               ValidateName();
               ValidateEmail();
               ValidatePhone();
               ValidateCedula();
               ValidateBirthDate();
               ValidateSupplierId();
          }

          private void ValidateName()
          {
               if (Name == null)
                    throw new InvalidUserException("Provider must have a name.");
          }

          private void ValidateEmail()
          {
               if (Email == null)
                    throw new InvalidUserException("Provider must have an email.");
          }

          private void ValidatePhone()
          {
               if (Phone == null)
                    throw new InvalidUserException("Provider must have a phone.");
          }

          private void ValidateCedula()
          {
               if (Cedula == null)
                    throw new InvalidUserException("Provider must have a cedula.");
          }

          private void ValidateBirthDate()
          {
               if (BirthDate == null)
                    throw new InvalidUserException("Provider must have a birth date.");
          }

          private void ValidateSupplierId()
          {
               if (SupplierId == null)
                    throw new InvalidUserException("Provider must have a supplier.");
          }

          public void ChangeName(UserName newName)
          {
               Name = newName ?? throw new ArgumentNullException(nameof(newName), "New name cannot be null.");
               ValidateState();
               AddDomainEvent(new UserNameChangedEvent(Id, newName));
          }

          public void ChangePhone(UserPhone newPhone)
          {
               Phone = newPhone ?? throw new ArgumentNullException(nameof(newPhone), "New phone cannot be null.");
               ValidateState();
               AddDomainEvent(new UserPhoneChangedEvent(Id, newPhone));
          }

          public void ChangeBirthDate(UserBirthDate newBirthDate)
          {
               BirthDate = newBirthDate ?? throw new ArgumentNullException(nameof(newBirthDate), "New birth date cannot be null.");
               ValidateState();
               AddDomainEvent(new UserBirthDateChangedEvent(Id, newBirthDate));
          }
     }
}