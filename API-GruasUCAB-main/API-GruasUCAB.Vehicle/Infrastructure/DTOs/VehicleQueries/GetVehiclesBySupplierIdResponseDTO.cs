namespace API_GruasUCAB.Vehicle.Infrastructure.DTOs.VehicleQueries
{
     public class GetVehiclesBySupplierIdResponseDTO
     {
          public List<VehicleDTO> Vehicles { get; set; } = new List<VehicleDTO>();
     }
}