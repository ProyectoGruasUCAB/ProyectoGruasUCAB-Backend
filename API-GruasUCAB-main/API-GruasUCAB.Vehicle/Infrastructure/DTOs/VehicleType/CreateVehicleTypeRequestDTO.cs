namespace API_GruasUCAB.Vehicle.Infrastructure.DTOs.VehicleType
{
     public class CreateVehicleTypeRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Name is required.")]
          [JsonPropertyOrder(2)]
          public string Name { get; set; } = string.Empty;

          [Required(ErrorMessage = "Description is required.")]
          [JsonPropertyOrder(2)]
          public string Description { get; set; } = string.Empty;
     }
}