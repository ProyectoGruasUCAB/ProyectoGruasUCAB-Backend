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
<<<<<<< HEAD

          public async Task<Driver> GetDriverById(UserId id)
          {
               // Implementa la lógica para obtener el conductor por su ID
               // Esto puede involucrar una llamada a un repositorio o una base de datos
               // Aquí se usa Task.FromResult como un ejemplo de implementación asincrónica
               return await Task.FromResult(new Driver(
                   id,
                   new UserName("Example Name"),
                   new UserEmail("example@example.com"),
                   new UserPhone("04240000000"),
                   new UserCedula("V-12345678"),
                   new UserBirthDate("01-01-2000"),
                   new UserCedulaExpirationDate("01-01-2025"),
                   new UserMedicalCertificate("Example Certificate"),
                   new UserMedicalCertificateExpirationDate("01-01-2025"),
                   new UserDriverLicense("Example License"),
                   new UserDriverLicenseExpirationDate("01-01-2025")
               ));
          }
=======
>>>>>>> origin/Development
     }
}