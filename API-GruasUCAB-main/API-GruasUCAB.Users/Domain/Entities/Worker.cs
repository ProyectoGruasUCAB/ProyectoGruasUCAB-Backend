namespace API_GruasUCAB.Users.Domain.Entities
{
     public class Worker : AggregateRoot<UserId>
     {
          public UserName Name { get; private set; }
          public UserEmail Email { get; private set; }
          public UserPhone Phone { get; private set; }
          public UserCedula Cedula { get; private set; }
          public UserBirthDate BirthDate { get; private set; }
          public UserPosition Position { get; private set; }
          public DepartmentId DepartmentId { get; private set; }

          public Worker(UserId id, UserName name, UserEmail email, UserPhone phone, UserCedula cedula, UserBirthDate birthDate, UserPosition position, DepartmentId departmentId)
              : base(id)
          {
               Name = name ?? throw new ArgumentNullException(nameof(name), "Worker must have a name.");
               Email = email ?? throw new ArgumentNullException(nameof(email), "Worker must have an email.");
               Phone = phone ?? throw new ArgumentNullException(nameof(phone), "Worker must have a phone.");
               Cedula = cedula ?? throw new ArgumentNullException(nameof(cedula), "Worker must have a cedula.");
               BirthDate = birthDate ?? throw new ArgumentNullException(nameof(birthDate), "Worker must have a birth date.");
               Position = position ?? throw new ArgumentNullException(nameof(position), "Worker must have a position.");
               DepartmentId = departmentId ?? throw new ArgumentNullException(nameof(departmentId), "Worker must have a department.");

               ValidateState();
               AddDomainEvent(new RecordWorkerDataEvent(id, name, email, phone, birthDate, position, departmentId));
          }

          protected override void ValidateState()
          {
               ValidateName();
               ValidateEmail();
               ValidatePhone();
               ValidateCedula();
               ValidateBirthDate();
               ValidatePosition();
               ValidateDepartmentId();
          }

          private void ValidateName()
          {
               if (Name == null)
                    throw new InvalidUserException("Worker must have a name.");
          }

          private void ValidateEmail()
          {
               if (Email == null)
                    throw new InvalidUserException("Worker must have an email.");
          }

          private void ValidatePhone()
          {
               if (Phone == null)
                    throw new InvalidUserException("Worker must have a phone.");
          }

          private void ValidateCedula()
          {
               if (Cedula == null)
                    throw new InvalidUserException("Worker must have a cedula.");
          }

          private void ValidateBirthDate()
          {
               if (BirthDate == null)
                    throw new InvalidUserException("Worker must have a birth date.");
          }

          private void ValidatePosition()
          {
               if (Position == null)
                    throw new InvalidUserPositionException("Worker must have a position.");
          }

          private void ValidateDepartmentId()
          {
               if (DepartmentId == null)
                    throw new InvalidDepartmentIdException();
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

          public void ChangePosition(UserPosition newPosition)
          {
               Position = newPosition ?? throw new ArgumentNullException(nameof(newPosition), "New position cannot be null.");
               ValidateState();
               AddDomainEvent(new UserPositionChangedEvent(Id, newPosition));
          }

          public void ChangeDepartmentId(DepartmentId newDepartmentId)
          {
               DepartmentId = newDepartmentId ?? throw new ArgumentNullException(nameof(newDepartmentId), "New department cannot be null.");
               ValidateState();
               AddDomainEvent(new DepartmentIdChangedEvent(Id, newDepartmentId));
          }
     }
}