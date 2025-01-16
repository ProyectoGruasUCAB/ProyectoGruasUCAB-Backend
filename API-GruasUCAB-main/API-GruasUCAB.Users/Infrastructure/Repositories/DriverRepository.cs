namespace API_GruasUCAB.Users.Infrastructure.Repositories
{
     public class DriverRepository : IDriverRepository
     {
          private readonly List<DriverDTO> _drivers;

          public DriverRepository()
          {
               // Inicializar la lista con datos de ejemplo
               _drivers = new List<DriverDTO>
            {
                new DriverDTO
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Driver1",
                    UserEmail = "driver1@example.com",
                    Phone = "0414567890",
                    Cedula = "V-12345678",
                    BirthDate = "01-01-2000",
                    CedulaExpirationDate = "01-01-2025",
                    MedicalCertificate = "Cert1",
                    MedicalCertificateExpirationDate = "01-01-2025",
                    DriverLicense = "License1",
                    DriverLicenseExpirationDate = "01-01-2025"
                },
                new DriverDTO
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Driver2",
                    UserEmail = "driver2@example.com",
                    Phone = "0424654321",
                    Cedula = "V-87654321",
                    BirthDate = "01-01-2000",
                    CedulaExpirationDate = "01-01-2025",
                    MedicalCertificate = "Cert2",
                    MedicalCertificateExpirationDate = "01-01-2025",
                    DriverLicense = "License2",
                    DriverLicenseExpirationDate = "01-01-2025"
                },
                new DriverDTO
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Driver3",
                    UserEmail = "driver3@example.com",
                    Phone = "04123344555",
                    Cedula = "V-11223344",
                    BirthDate = "01-01-2000",
                    CedulaExpirationDate = "01-01-2026",
                    MedicalCertificate = "Cert3",
                    MedicalCertificateExpirationDate = "01-01-2026",
                    DriverLicense = "License3",
                    DriverLicenseExpirationDate = "01-01-2026"
                }
            };
          }

          public async Task<List<DriverDTO>> GetAllDriversAsync()
          {
               // Simulación de una llamada a la base de datos
               return await Task.FromResult(_drivers);
          }

          public async Task<DriverDTO> GetDriverByIdAsync(Guid id)
          {
               // Simulación de una llamada a la base de datos
               var driver = _drivers.FirstOrDefault(d => d.Id == id);
               if (driver == null)
               {
                    throw new KeyNotFoundException($"Driver with ID {id} not found.");
               }
               return await Task.FromResult(driver);
          }

          public async Task<List<DriverDTO>> GetDriversByNameAsync(string name)
          {
               // Simulación de una llamada a la base de datos
               var drivers = _drivers.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
               if (!drivers.Any())
               {
                    throw new KeyNotFoundException($"No drivers with name containing '{name}' found.");
               }
               return await Task.FromResult(drivers);
          }

          public async Task AddDriverAsync(DriverDTO driver)
          {
               // Simulación de una llamada a la base de datos
               _drivers.Add(driver);
               await Task.CompletedTask;
          }

          public async Task UpdateDriverAsync(DriverDTO driver)
          {
               // Simulación de una llamada a la base de datos
               var existingDriver = _drivers.FirstOrDefault(d => d.Id == driver.Id);
               if (existingDriver == null)
               {
                    throw new KeyNotFoundException($"Driver with ID {driver.Id} not found.");
               }

               existingDriver.Name = driver.Name;
               existingDriver.UserEmail = driver.UserEmail;
               existingDriver.Phone = driver.Phone;
               existingDriver.Cedula = driver.Cedula;
               existingDriver.BirthDate = driver.BirthDate;
               existingDriver.CedulaExpirationDate = driver.CedulaExpirationDate;
               existingDriver.MedicalCertificate = driver.MedicalCertificate;
               existingDriver.MedicalCertificateExpirationDate = driver.MedicalCertificateExpirationDate;
               existingDriver.DriverLicense = driver.DriverLicense;
               existingDriver.DriverLicenseExpirationDate = driver.DriverLicenseExpirationDate;

               await Task.CompletedTask;
          }
     }
}