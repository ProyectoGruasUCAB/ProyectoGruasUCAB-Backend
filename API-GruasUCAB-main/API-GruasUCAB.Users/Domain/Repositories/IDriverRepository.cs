namespace API_GruasUCAB.Users.Domain.Repositories
{
     public interface IDriverRepository
     {
          Task<List<DriverDTO>> GetAllDriversAsync();
          Task<DriverDTO> GetDriverByIdAsync(Guid id);
          Task<List<DriverDTO>> GetDriversByNameAsync(string name);
          Task<List<DriverDTO>> GetDriversBySupplierIdAsync(Guid supplierId);
          Task AddDriverAsync(DriverDTO driver);
          Task UpdateDriverAsync(DriverDTO driver);
     }
}