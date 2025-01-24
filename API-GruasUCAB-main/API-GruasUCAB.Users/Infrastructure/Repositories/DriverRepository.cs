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
               var drivers = await _context.Drivers.ToListAsync();
               return drivers.Select(driver => driver.ToDTO()).ToList();
          }

          public async Task<DriverDTO> GetDriverByIdAsync(Guid id)
          {
               var driver = await _context.Drivers.FindAsync(new UserId(id));
               if (driver == null)
               {
                    throw new KeyNotFoundException($"Driver with ID {id} not found.");
               }

               return driver.ToDTO();
          }

          public async Task<List<DriverDTO>> GetDriversByNameAsync(string name)
          {
               var drivers = await _context.Drivers
                   .ToListAsync();

               var filteredDrivers = drivers
                   .Where(d => d.Name.Value.ToLower().Contains(name.ToLower()))
                   .ToList();

               if (!filteredDrivers.Any())
               {
                    throw new KeyNotFoundException($"No drivers with name containing '{name}' found.");
               }

               return filteredDrivers.Select(driver => driver.ToDTO()).ToList();
          }

          public async Task<List<DriverDTO>> GetDriversBySupplierIdAsync(Guid supplierId)
          {
               var drivers = await _context.Drivers
                   .ToListAsync();

               var filteredDrivers = drivers
                   .Where(d => d.SupplierId.Value == supplierId)
                   .ToList();

               return filteredDrivers.Select(driver => driver.ToDTO()).ToList();
          }

          public async Task AddDriverAsync(DriverDTO driverDto)
          {
               var driver = driverDto.ToEntity();
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

               var updatedDriver = driverDto.ToEntity();
               _context.Entry(existingDriver).CurrentValues.SetValues(updatedDriver);
               await _context.SaveChangesAsync();
          }
     }
}