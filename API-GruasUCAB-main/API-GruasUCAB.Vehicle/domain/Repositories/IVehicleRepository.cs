namespace API_GruasUCAB.Vehicle.Domain.Repositories
{
     public interface IVehicleRepository
     {
          Task<List<VehicleDTO>> GetAllVehiclesAsync();
          Task<VehicleDTO> GetVehicleByIdAsync(Guid id);
          Task<VehicleDTO> GetVehicleByLicensePlateAsync(string licensePlate);
          Task<List<VehicleDTO>> GetVehiclesBySupplierIdAsync(Guid supplierId);
          Task<List<VehicleDTO>> GetVehiclesByDriverIdIsNotNullAsync();
          Task AddVehicleAsync(VehicleDTO vehicle);
          Task UpdateVehicleAsync(VehicleDTO vehicle);
     }
}