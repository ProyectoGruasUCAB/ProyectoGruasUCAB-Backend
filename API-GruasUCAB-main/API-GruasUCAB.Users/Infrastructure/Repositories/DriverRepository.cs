namespace API_GruasUCAB.Users.Infrastructure.Repositories
{
     public class DriverRepository : IDriverRepository
     {
          private readonly UserDbContext _context;

          public DriverRepository(UserDbContext context)
          {
               _context = context;
          }

          public async Task<List<DriverDTO>> GetAllDriversAsync()
          {
               return await _context.Drivers
                   .Select(d => new DriverDTO
                   {
                        Id = d.Id.Value,
                        Name = d.Name.Value,
                        UserEmail = d.Email.Value,
                        Phone = d.Phone.Value,
                        Cedula = d.Cedula.Value,
                        BirthDate = d.BirthDate.Value.ToString("dd-MM-yyyy"),
                        MedicalCertificate = d.MedicalCertificate.Value,
                        MedicalCertificateExpirationDate = d.MedicalCertificateExpirationDate.Value.ToString("dd-MM-yyyy"),
                        DriverLicense = d.DriverLicense.Value,
                        DriverLicenseExpirationDate = d.DriverLicenseExpirationDate.Value.ToString("dd-MM-yyyy"),
                        SupplierId = d.SupplierId.Value,
                        Token = d.Token != null ? d.Token.Value : null
                   })
                   .ToListAsync();
          }

          public async Task<DriverDTO> GetDriverByIdAsync(Guid id)
          {
               var driver = await _context.Drivers.FindAsync(new UserId(id));
               if (driver == null)
               {
                    throw new KeyNotFoundException($"Driver with ID {id} not found.");
               }

               return new DriverDTO
               {
                    Id = driver.Id.Value,
                    Name = driver.Name.Value,
                    UserEmail = driver.Email.Value,
                    Phone = driver.Phone.Value,
                    Cedula = driver.Cedula.Value,
                    BirthDate = driver.BirthDate.Value.ToString("dd-MM-yyyy"),
                    MedicalCertificate = driver.MedicalCertificate.Value,
                    MedicalCertificateExpirationDate = driver.MedicalCertificateExpirationDate.Value.ToString("dd-MM-yyyy"),
                    DriverLicense = driver.DriverLicense.Value,
                    DriverLicenseExpirationDate = driver.DriverLicenseExpirationDate.Value.ToString("dd-MM-yyyy"),
                    SupplierId = driver.SupplierId.Value,
                    Token = driver.Token?.Value
               };
          }

          public async Task<List<DriverDTO>> GetDriversByNameAsync(string name)
          {
               var drivers = await _context.Drivers
                   .ToListAsync();

               var filteredDrivers = drivers
                   .Where(d => d.Name.Value.ToLower().Contains(name.ToLower()))
                   .Select(d => new DriverDTO
                   {
                        Id = d.Id.Value,
                        Name = d.Name.Value,
                        UserEmail = d.Email.Value,
                        Phone = d.Phone.Value,
                        Cedula = d.Cedula.Value,
                        BirthDate = d.BirthDate.Value.ToString("dd-MM-yyyy"),
                        MedicalCertificate = d.MedicalCertificate.Value,
                        MedicalCertificateExpirationDate = d.MedicalCertificateExpirationDate.Value.ToString("dd-MM-yyyy"),
                        DriverLicense = d.DriverLicense.Value,
                        DriverLicenseExpirationDate = d.DriverLicenseExpirationDate.Value.ToString("dd-MM-yyyy"),
                        SupplierId = d.SupplierId.Value,
                        Token = d.Token?.Value
                   })
                   .ToList();

               if (!filteredDrivers.Any())
               {
                    throw new KeyNotFoundException($"No drivers with name containing '{name}' found.");
               }

               return filteredDrivers;
          }

          public async Task AddDriverAsync(DriverDTO driverDto)
          {
               var driver = new Driver(
                   new UserId(driverDto.Id),
                   new UserName(driverDto.Name),
                   new UserEmail(driverDto.UserEmail),
                   new UserPhone(driverDto.Phone),
                   new UserCedula(driverDto.Cedula),
                   new UserBirthDate(driverDto.BirthDate),
                   new UserMedicalCertificate(driverDto.MedicalCertificate),
                   new UserMedicalCertificateExpirationDate(driverDto.MedicalCertificateExpirationDate),
                   new UserDriverLicense(driverDto.DriverLicense),
                   new UserDriverLicenseExpirationDate(driverDto.DriverLicenseExpirationDate),
                   new SupplierId(driverDto.SupplierId),
                   driverDto.Token != null ? new UserToken(driverDto.Token) : null
               );

               _context.Drivers.Add(driver);
               await _context.SaveChangesAsync();
          }

          public async Task UpdateDriverAsync(DriverDTO driverDto)
          {
               var existingDriver = await _context.Drivers.FindAsync(new UserId(driverDto.Id));
               if (existingDriver == null)
               {
                    throw new KeyNotFoundException($"Driver with ID {driverDto.Id} not found.");
               }

               existingDriver.ChangeName(new UserName(driverDto.Name));
               existingDriver.ChangePhone(new UserPhone(driverDto.Phone));
               existingDriver.ChangeBirthDate(new UserBirthDate(driverDto.BirthDate));
               existingDriver.ChangeMedicalCertificate(new UserMedicalCertificate(driverDto.MedicalCertificate));
               existingDriver.ChangeDriverLicense(new UserDriverLicense(driverDto.DriverLicense));
               existingDriver.ChangeMedicalCertificateExpirationDate(new UserMedicalCertificateExpirationDate(driverDto.MedicalCertificateExpirationDate));
               existingDriver.ChangeDriverLicenseExpirationDate(new UserDriverLicenseExpirationDate(driverDto.DriverLicenseExpirationDate));
               existingDriver.ChangeSupplierId(new SupplierId(driverDto.SupplierId));

               if (!string.IsNullOrEmpty(driverDto.Token))
               {
                    existingDriver.ChangeToken(new UserToken(driverDto.Token));
               }

               await _context.SaveChangesAsync();
          }
     }
}