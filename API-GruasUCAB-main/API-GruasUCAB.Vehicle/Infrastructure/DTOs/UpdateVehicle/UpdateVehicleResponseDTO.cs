namespace API_GruasUCAB.Vehicle.Infrastructure.DTOs.UpdateVehicle
{
     public class UpdateVehicleResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid VehicleId { get; set; }

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
     }
}