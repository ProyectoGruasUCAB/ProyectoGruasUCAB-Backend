

namespace API_GruasUCAB.Users.Domain.Entities
{
     public class Administrator : AggregateRoot<UserId>
     {
          public UserName Name { get; private set; }
          public UserEmail Email { get; private set; }
          public UserPhone Phone { get; private set; }
          public UserCedula Cedula { get; private set; }
          public UserBirthDate BirthDate { get; private set; }

          public Administrator(UserId id, UserName name, UserEmail email, UserPhone phone, UserCedula cedula, UserBirthDate birthDate)
              : base(id)
          {
               Name = name ?? throw new ArgumentNullException(nameof(name), "Administrator must have a name.");
               Email = email ?? throw new ArgumentNullException(nameof(email), "Administrator must have an email.");
               Phone = phone ?? throw new ArgumentNullException(nameof(phone), "Administrator must have a phone.");
               Cedula = cedula ?? throw new ArgumentNullException(nameof(cedula), "Administrator must have a cedula.");
               BirthDate = birthDate ?? throw new ArgumentNullException(nameof(birthDate), "Administrator must have a birth date.");

               ValidateState();
               AddDomainEvent(new RecordAdministratorDataEvent(id, name, email, phone, birthDate));
          }

          protected override void ValidateState()
          {
               ValidateName();
               ValidateEmail();
               ValidatePhone();
               ValidateCedula();
               ValidateBirthDate();
          }

          private void ValidateName()
          {
               if (Name == null)
                    throw new InvalidUserException("Administrator must have a name.");
          }

          private void ValidateEmail()
          {
               if (Email == null)
                    throw new InvalidUserException("Administrator must have an email.");
          }

          private void ValidatePhone()
          {
               if (Phone == null)
                    throw new InvalidUserException("Administrator must have a phone.");
          }

          private void ValidateCedula()
          {
               if (Cedula == null)
                    throw new InvalidUserException("Administrator must have a cedula.");
          }

          private void ValidateBirthDate()
          {
               if (BirthDate == null)
                    throw new InvalidUserException("Administrator must have a birth date.");
          }

          public void ChangeName(UserName newName)
          {
               if (newName == null)
                    throw new ArgumentNullException(nameof(newName), "New name cannot be null.");
               Name = newName;
               ValidateState();
               AddDomainEvent(new UserNameChangedEvent(Id, newName));
          }

          public void ChangePhone(UserPhone newPhone)
          {
               if (newPhone == null)
                    throw new ArgumentNullException(nameof(newPhone), "New phone cannot be null.");
               Phone = newPhone;
               ValidateState();
               AddDomainEvent(new UserPhoneChangedEvent(Id, newPhone));
          }

          public void ChangeBirthDate(UserBirthDate newBirthDate)
          {
               if (newBirthDate == null)
                    throw new ArgumentNullException(nameof(newBirthDate), "New birth date cannot be null.");
               BirthDate = newBirthDate;
               ValidateState();
               AddDomainEvent(new UserBirthDateChangedEvent(Id, newBirthDate));
          }
     }
}