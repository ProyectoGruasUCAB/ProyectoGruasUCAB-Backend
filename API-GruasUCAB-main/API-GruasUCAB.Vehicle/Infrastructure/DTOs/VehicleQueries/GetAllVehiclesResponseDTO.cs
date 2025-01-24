namespace API_GruasUCAB.Vehicle.Infrastructure.DTOs.VehicleQueries
{
     public class GetAllVehiclesResponseDTO
     {
          public List<VehicleDTO> Vehicles { get; set; } = new List<VehicleDTO>();
     }
}