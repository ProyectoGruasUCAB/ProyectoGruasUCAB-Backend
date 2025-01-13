namespace API_GruasUCAB.Vehicle.Infrastructure.DTOs.CreateVehicle
{
     public class CreateVehicleResponseDTO : BaseResponseDTO
     {
          [Required(ErrorMessage = "Vehicle ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid VehicleId { get; set; }
     }
}