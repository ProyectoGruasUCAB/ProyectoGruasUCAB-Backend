namespace API_GruasUCAB.Users.Domain.Factories
{
     public class DriverFactory : IDriverFactory
     {
          private readonly IDriverRepository _driverRepository;

          public DriverFactory(IDriverRepository driverRepository)
          {
               _driverRepository = driverRepository;
          }

          public Driver CreateDriver(
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
              SupplierId supplierId)
          {
               return new Driver(id, name, email, phone, cedula, birthDate, medicalCertificate, medicalCertificateExpirationDate, driverLicense, driverLicenseExpirationDate, supplierId);
          }

          public async Task<Driver> GetDriverById(UserId id)
          {
               var driverDTO = await _driverRepository.GetDriverByIdAsync(id.Id);
               return new Driver(
                   new UserId(driverDTO.Id),
                   new UserName(driverDTO.Name),
                   new UserEmail(driverDTO.UserEmail),
                   new UserPhone(driverDTO.Phone),
                   new UserCedula(driverDTO.Cedula),
                   new UserBirthDate(driverDTO.BirthDate),
                   new UserMedicalCertificate(driverDTO.MedicalCertificate),
                   new UserMedicalCertificateExpirationDate(driverDTO.MedicalCertificateExpirationDate),
                   new UserDriverLicense(driverDTO.DriverLicense),
                   new UserDriverLicenseExpirationDate(driverDTO.DriverLicenseExpirationDate),
                   new SupplierId(driverDTO.SupplierId)
               );
          }
     }
}