namespace API_GruasUCAB.Vehicle.Infrastructure.DTOs.VehicleTypeQueries
{
     public class GetAllVehicleTypesResponseDTO
     {
          public List<VehicleTypeDTO> VehicleTypes { get; set; } = new List<VehicleTypeDTO>();
     }
}