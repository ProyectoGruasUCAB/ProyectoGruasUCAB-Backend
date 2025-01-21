namespace API_GruasUCAB.Vehicle.Infrastructure.DTOs.VehicleType
{
     public class UpdateVehicleTypeRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Vehicle Type ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid VehicleTypeId { get; set; }

          [JsonPropertyOrder(2)]
          public string? Name { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? Description { get; set; } = string.Empty;
     }
}