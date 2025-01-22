namespace API_GruasUCAB.Vehicle.Domain.Repositories
{
     public interface IVehicleTypeRepository
     {
          Task<List<VehicleTypeDTO>> GetAllVehicleTypesAsync();
          Task<VehicleTypeDTO> GetVehicleTypeByIdAsync(Guid id);
          Task<VehicleTypeDTO> GetVehicleTypeByNameAsync(string name);
          Task AddVehicleTypeAsync(VehicleTypeDTO vehicleType);
          Task UpdateVehicleTypeAsync(VehicleTypeDTO vehicleType);
     }
}