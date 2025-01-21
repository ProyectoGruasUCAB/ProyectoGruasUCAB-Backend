namespace API_GruasUCAB.Users.Domain.Entities
{
     public class Driver : AggregateRoot<UserId>
     {
          public UserName Name { get; private set; }
          public UserEmail Email { get; private set; }
          public UserPhone Phone { get; private set; }
          public UserCedula Cedula { get; private set; }
          public UserBirthDate BirthDate { get; private set; }
          public UserMedicalCertificate MedicalCertificate { get; private set; }
          public UserMedicalCertificateExpirationDate MedicalCertificateExpirationDate { get; private set; }
          public UserDriverLicense DriverLicense { get; private set; }
          public UserDriverLicenseExpirationDate DriverLicenseExpirationDate { get; private set; }
          public SupplierId SupplierId { get; private set; }
          public UserToken? Token { get; private set; }

          public Driver(UserId id, UserName name, UserEmail email, UserPhone phone, UserCedula cedula,
                        UserBirthDate birthDate, UserMedicalCertificate medicalCertificate, UserMedicalCertificateExpirationDate medicalCertificateExpirationDate,
                        UserDriverLicense driverLicense, UserDriverLicenseExpirationDate driverLicenseExpirationDate, SupplierId supplierId, UserToken? token = null)
              : base(id)
          {
               Name = name ?? throw new ArgumentNullException(nameof(name), "Driver must have a name.");
               Email = email ?? throw new ArgumentNullException(nameof(email), "Driver must have an email.");
               Phone = phone ?? throw new ArgumentNullException(nameof(phone), "Driver must have a phone.");
               Cedula = cedula ?? throw new ArgumentNullException(nameof(cedula), "Driver must have a cedula.");
               BirthDate = birthDate ?? throw new ArgumentNullException(nameof(birthDate), "Driver must have a birth date.");
               MedicalCertificate = medicalCertificate ?? throw new ArgumentNullException(nameof(medicalCertificate), "Driver must have a medical certificate.");
               MedicalCertificateExpirationDate = medicalCertificateExpirationDate ?? throw new ArgumentNullException(nameof(medicalCertificateExpirationDate), "Driver must have a medical certificate expiration date.");
               DriverLicense = driverLicense ?? throw new ArgumentNullException(nameof(driverLicense), "Driver must have a driver license.");
               DriverLicenseExpirationDate = driverLicenseExpirationDate ?? throw new ArgumentNullException(nameof(driverLicenseExpirationDate), "Driver must have a driver license expiration date.");
               SupplierId = supplierId ?? throw new ArgumentNullException(nameof(supplierId), "Driver must have a supplier.");
               Token = token;

               ValidateState();
               AddDomainEvent(new RecordDriverDataEvent(id, name, email, phone, birthDate, medicalCertificate, medicalCertificateExpirationDate, driverLicense, driverLicenseExpirationDate, supplierId, token));
          }

          protected override void ValidateState()
          {
               ValidateName();
               ValidateEmail();
               ValidatePhone();
               ValidateCedula();
               ValidateBirthDate();
               ValidateMedicalCertificate();
               ValidateDriverLicense();
               ValidateSupplierId();
          }

          private void ValidateName()
          {
               if (Name == null)
                    throw new InvalidUserException("Driver must have a name.");
          }

          private void ValidateEmail()
          {
               if (Email == null)
                    throw new InvalidUserException("Driver must have an email.");
          }

          private void ValidatePhone()
          {
               if (Phone == null)
                    throw new InvalidUserException("Driver must have a phone.");
          }

          private void ValidateCedula()
          {
               if (Cedula == null)
                    throw new InvalidUserException("Driver must have a cedula.");
          }

          private void ValidateBirthDate()
          {
               if (BirthDate == null)
                    throw new InvalidUserException("Driver must have a birth date.");
          }

          private void ValidateMedicalCertificate()
          {
               if (MedicalCertificate == null)
                    throw new InvalidUserException("Driver must have a medical certificate.");
          }

          private void ValidateDriverLicense()
          {
               if (DriverLicense == null)
                    throw new InvalidUserException("Driver must have a driver license.");
          }

          private void ValidateSupplierId()
          {
               if (SupplierId == null)
                    throw new InvalidSupplierIdException();
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

          public void ChangeMedicalCertificate(UserMedicalCertificate newMedicalCertificate)
          {
               MedicalCertificate = newMedicalCertificate ?? throw new ArgumentNullException(nameof(newMedicalCertificate), "New medical certificate cannot be null.");
               ValidateState();
               AddDomainEvent(new UserMedicalCertificateChangedEvent(Id, newMedicalCertificate));
          }

          public void ChangeDriverLicense(UserDriverLicense newDriverLicense)
          {
               DriverLicense = newDriverLicense ?? throw new ArgumentNullException(nameof(newDriverLicense), "New driver license cannot be null.");
               ValidateState();
               AddDomainEvent(new UserDriverLicenseChangedEvent(Id, newDriverLicense));
          }

          public void ChangeMedicalCertificateExpirationDate(UserMedicalCertificateExpirationDate newDate)
          {
               MedicalCertificateExpirationDate = newDate ?? throw new ArgumentNullException(nameof(newDate), "New medical certificate expiration date cannot be null.");
               ValidateState();
               AddDomainEvent(new UserMedicalCertificateExpirationDateChangedEvent(Id, newDate));
          }

          public void ChangeDriverLicenseExpirationDate(UserDriverLicenseExpirationDate newDate)
          {
               DriverLicenseExpirationDate = newDate ?? throw new ArgumentNullException(nameof(newDate), "New driver license expiration date cannot be null.");
               ValidateState();
               AddDomainEvent(new UserDriverLicenseExpirationDateChangedEvent(Id, newDate));
          }

          public void ChangeSupplierId(SupplierId newSupplierId)
          {
               SupplierId = newSupplierId ?? throw new ArgumentNullException(nameof(newSupplierId), "New supplier cannot be null.");
               ValidateState();
               AddDomainEvent(new SupplierIdChangedEvent(Id, newSupplierId));
          }

          public void ChangeToken(UserToken newToken)
          {
               Token = newToken;
               AddDomainEvent(new UserTokenChangedEvent(Id, newToken));
          }
     }
}