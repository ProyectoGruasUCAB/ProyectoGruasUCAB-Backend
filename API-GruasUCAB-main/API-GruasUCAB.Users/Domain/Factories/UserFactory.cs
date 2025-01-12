namespace API_GruasUCAB.Users.Domain.Factories
{
     public class UserFactory : IUserFactory
     {
          public Administrator RecordAdministratorDataEvent(
              UserId id,
              UserName name,
              UserEmail email,
              UserPhone phone,
              UserCedula cedula,
              UserBirthDate birthDate)
          {
               return new Administrator(id, name, email, phone, cedula, birthDate);
          }

          public Worker RecordWorkerDataEvent(
              UserId id,
              UserName name,
              UserEmail email,
              UserPhone phone,
              UserCedula cedula,
              UserBirthDate birthDate,
              UserPosition position)
          {
               return new Worker(id, name, email, phone, cedula, birthDate, position);
          }

          public Supplier RecordSupplierDataEvent(
              UserId id,
              UserName name,
              UserEmail email,
              UserPhone phone,
              UserCedula cedula,
              UserBirthDate birthDate)
          {
               return new Supplier(id, name, email, phone, cedula, birthDate);
          }

          public Driver RecordDriverDataEvent(
              UserId id,
              UserName name,
              UserEmail email,
              UserPhone phone,
              UserCedula cedula,
              UserBirthDate birthDate,
              UserCedulaExpirationDate cedulaExpirationDate,
              UserMedicalCertificate medicalCertificate,
              UserMedicalCertificateExpirationDate medicalCertificateExpirationDate,
              UserDriverLicense driverLicense,
              UserDriverLicenseExpirationDate driverLicenseExpirationDate)
          {
               return new Driver(id, name, email, phone, cedula, birthDate, cedulaExpirationDate, medicalCertificate, medicalCertificateExpirationDate, driverLicense, driverLicenseExpirationDate);
          }
     }
}