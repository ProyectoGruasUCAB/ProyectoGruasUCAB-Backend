namespace API_GruasUCAB.Vehicle.Infrastructure.DTOs.UpdateVehicle
{
     public class UpdateVehicleResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid VehicleId { get; set; }
     }
}