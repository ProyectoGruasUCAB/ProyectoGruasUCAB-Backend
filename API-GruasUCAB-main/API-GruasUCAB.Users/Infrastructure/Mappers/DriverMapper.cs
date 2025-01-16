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
                    CedulaExpirationDate = driver.CedulaExpirationDate.Value.ToString("dd-MM-yyyy"),
                    MedicalCertificate = driver.MedicalCertificate.Value,
                    MedicalCertificateExpirationDate = driver.MedicalCertificateExpirationDate.Value.ToString("dd-MM-yyyy"),
                    DriverLicense = driver.DriverLicense.Value,
                    DriverLicenseExpirationDate = driver.DriverLicenseExpirationDate.Value.ToString("dd-MM-yyyy")
               };
          }
     }
}