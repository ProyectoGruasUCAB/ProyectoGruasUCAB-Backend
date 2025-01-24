namespace API_GruasUCAB.Users.Infrastructure.Mappers
{
     public static class DriverMapper
     {
          public static DriverDTO ToDTO(this Driver driver)
          {
               return new DriverDTO
               {
                    Id = driver.Id.Id,
                    Name = driver.Name.Value,
                    UserEmail = driver.Email.Value,
                    Phone = driver.Phone.Value,
                    Cedula = driver.Cedula.Value,
                    BirthDate = driver.BirthDate.Value.ToString("dd-MM-yyyy"),
                    MedicalCertificate = driver.MedicalCertificate.Value,
                    MedicalCertificateExpirationDate = driver.MedicalCertificateExpirationDate.ExpirationDate.ToString("dd-MM-yyyy"),
                    DriverLicense = driver.DriverLicense.Value,
                    DriverLicenseExpirationDate = driver.DriverLicenseExpirationDate.ExpirationDate.ToString("dd-MM-yyyy"),
                    SupplierId = driver.SupplierId.Id,
                    Token = driver.Token != null ? driver.Token.Value : null
               };
          }

          public static Driver ToEntity(this DriverDTO driverDTO)
          {
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
                   new SupplierId(driverDTO.SupplierId),
                   driverDTO.Token != null ? new UserToken(driverDTO.Token) : null
               );
          }
     }
}