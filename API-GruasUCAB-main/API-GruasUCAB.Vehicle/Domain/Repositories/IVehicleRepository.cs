namespace API_GruasUCAB.Vehicle.Domain.Repositories
{
     public interface IVehicleRepository
     {
          Task<List<VehicleDTO>> GetAllVehiclesAsync();
          Task<VehicleDTO> GetVehicleByIdAsync(Guid id);
          Task<VehicleDTO> GetVehicleByLicensePlateAsync(string licensePlate);
          Task AddVehicleAsync(VehicleDTO vehicle);
          Task UpdateVehicleAsync(VehicleDTO vehicle);
     }
}