namespace API_GruasUCAB.Vehicle.Infrastructure.DTOs.UpdateVehicle
{
     public class UpdateVehicleRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Vehicle ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid VehicleId { get; set; }

          [JsonPropertyOrder(2)]
          public Guid? DriverId { get; set; }

          [JsonPropertyOrder(2)]
          public string? CivilLiability { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? CivilLiabilityExpirationDate { get; set; }

          [JsonPropertyOrder(2)]
          public string? TrafficLicense { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? LicensePlate { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? Brand { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? Color { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? Model { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public Guid? VehicleTypeId { get; set; }
     }
}