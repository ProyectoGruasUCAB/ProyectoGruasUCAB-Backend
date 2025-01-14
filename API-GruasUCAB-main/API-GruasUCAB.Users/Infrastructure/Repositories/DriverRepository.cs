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
                    Id = Guid.Parse("123e4567-e89b-12d3-a456-426614174001"),
                    Name = "Jane Doe",
                    UserEmail = "jane.doe@example.com",
                    Phone = "04248765432",
                    Cedula = "V-87654321",
                    BirthDate = "12-12-2000",
                    CedulaExpirationDate = "12-12-2025",
                    MedicalCertificate = "Valid",
                    MedicalCertificateExpirationDate = "12-12-2030",
                    DriverLicense = "B1234567",
                    DriverLicenseExpirationDate = "27-12-2025"
                },
                new DriverDTO
                {
                    Id = Guid.Parse("123e4567-e89b-12d3-a456-426614174002"),
                    Name = "John Smith",
                    UserEmail = "john.smith@example.com",
                    Phone = "04248765433",
                    Cedula = "V-87654322",
                    BirthDate = "10-10-1995",
                    CedulaExpirationDate = "10-10-2025",
                    MedicalCertificate = "Valid",
                    MedicalCertificateExpirationDate = "10-10-2030",
                    DriverLicense = "B1234568",
                    DriverLicenseExpirationDate = "10-10-2025"
                },
                new DriverDTO
                {
                    Id = Guid.Parse("123e4567-e89b-12d3-a456-426614174003"),
                    Name = "Alice Johnson",
                    UserEmail = "alice.johnson@example.com",
                    Phone = "04248765434",
                    Cedula = "V-87654323",
                    BirthDate = "05-05-1990",
                    CedulaExpirationDate = "05-05-2025",
                    MedicalCertificate = "Valid",
                    MedicalCertificateExpirationDate = "05-05-2030",
                    DriverLicense = "B1234569",
                    DriverLicenseExpirationDate = "05-05-2025"
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
     }
}