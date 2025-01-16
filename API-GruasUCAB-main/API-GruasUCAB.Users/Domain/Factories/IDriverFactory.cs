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
              UserCedulaExpirationDate cedulaExpirationDate,
              UserMedicalCertificate medicalCertificate,
              UserMedicalCertificateExpirationDate medicalCertificateExpirationDate,
              UserDriverLicense driverLicense,
              UserDriverLicenseExpirationDate driverLicenseExpirationDate);
<<<<<<< HEAD

          Task<Driver> GetDriverById(UserId id);
=======
>>>>>>> origin/Development
     }
}