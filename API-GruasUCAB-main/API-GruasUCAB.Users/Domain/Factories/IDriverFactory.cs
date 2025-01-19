namespace API_GruasUCAB.Users.Domain.Factories
{
     public interface IDriverFactory
     {
          Driver CreateDriver(
              UserId id,
              UserName name,
              UserEmail email,
              UserPhone phone,
              UserCedula cedula,
              UserBirthDate birthDate,
              UserMedicalCertificate medicalCertificate,
              UserMedicalCertificateExpirationDate medicalCertificateExpirationDate,
              UserDriverLicense driverLicense,
              UserDriverLicenseExpirationDate driverLicenseExpirationDate,
              SupplierId supplierId);

          Task<Driver> GetDriverById(UserId id);
     }
}