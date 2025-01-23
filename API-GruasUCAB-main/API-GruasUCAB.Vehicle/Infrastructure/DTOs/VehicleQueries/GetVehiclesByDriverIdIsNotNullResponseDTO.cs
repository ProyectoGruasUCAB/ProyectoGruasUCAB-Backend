namespace API_GruasUCAB.Vehicle.Infrastructure.DTOs.VehicleQueries
{
     public class GetVehiclesByDriverIdIsNotNullResponseDTO
     {
          public List<VehicleDTO> Vehicles { get; set; } = new List<VehicleDTO>();
     }
}