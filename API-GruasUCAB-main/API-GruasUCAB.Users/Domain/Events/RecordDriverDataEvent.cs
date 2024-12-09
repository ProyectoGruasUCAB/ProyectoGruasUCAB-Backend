namespace API_GruasUCAB.Users.Domain.Events
{
     public class RecordDriverDataEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public UserName UserName { get; }
          public UserEmail Email { get; }
          public UserPhone Phone { get; }
          public UserBirthDate BirthDate { get; }
          public UserCedulaExpirationDate CedulaExpirationDate { get; }
          public UserMedicalCertificate MedicalCertificate { get; }
          public UserMedicalCertificateExpirationDate MedicalCertificateExpirationDate { get; }
          public UserDriverLicense DriverLicense { get; }
          public UserDriverLicenseExpirationDate DriverLicenseExpirationDate { get; }

          public RecordDriverDataEvent(UserId userId, UserName userName, UserEmail email, UserPhone phone, UserBirthDate birthDate,
                                       UserCedulaExpirationDate cedulaExpirationDate, UserMedicalCertificate medicalCertificate, UserMedicalCertificateExpirationDate medicalCertificateExpirationDate,
                                       UserDriverLicense driverLicense, UserDriverLicenseExpirationDate driverLicenseExpirationDate)
          {
               UserId = userId ?? throw new ArgumentNullException(nameof(userId), "UserId cannot be null.");
               UserName = userName ?? throw new ArgumentNullException(nameof(userName), "UserName cannot be null.");
               Email = email ?? throw new ArgumentNullException(nameof(email), "Email cannot be null.");
               Phone = phone ?? throw new ArgumentNullException(nameof(phone), "Phone cannot be null.");
               BirthDate = birthDate ?? throw new ArgumentNullException(nameof(birthDate), "BirthDate cannot be null.");
               CedulaExpirationDate = cedulaExpirationDate ?? throw new ArgumentNullException(nameof(cedulaExpirationDate), "CedulaExpirationDate cannot be null.");
               MedicalCertificate = medicalCertificate ?? throw new ArgumentNullException(nameof(medicalCertificate), "MedicalCertificate cannot be null.");
               MedicalCertificateExpirationDate = medicalCertificateExpirationDate ?? throw new ArgumentNullException(nameof(medicalCertificateExpirationDate), "MedicalCertificateExpirationDate cannot be null.");
               DriverLicense = driverLicense ?? throw new ArgumentNullException(nameof(driverLicense), "DriverLicense cannot be null.");
               DriverLicenseExpirationDate = driverLicenseExpirationDate ?? throw new ArgumentNullException(nameof(driverLicenseExpirationDate), "DriverLicenseExpirationDate cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => UserId.Id;
          public string Name => nameof(RecordDriverDataEvent);
          public DateTime Timestamp { get; }
          public object Context => this;
     }
}