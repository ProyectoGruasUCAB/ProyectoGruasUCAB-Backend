namespace API_GruasUCAB.Users.Domain.Factories
{
     public class DriverFactory : IDriverFactory
     {
          public Driver CreateDriver(
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