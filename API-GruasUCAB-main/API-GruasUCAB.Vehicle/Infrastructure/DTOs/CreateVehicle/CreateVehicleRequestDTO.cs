namespace API_GruasUCAB.Vehicle.Infrastructure.DTOs.CreateVehicle
{
     public class CreateVehicleRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Civil Liability is required.")]
          [JsonPropertyOrder(2)]
          public string CivilLiability { get; set; } = string.Empty;

          [Required(ErrorMessage = "Civil Liability Expiration Date is required.")]
          [JsonPropertyOrder(2)]
          public string CivilLiabilityExpirationDate { get; set; } = string.Empty;

          [Required(ErrorMessage = "Traffic License is required.")]
          [JsonPropertyOrder(2)]
          public string TrafficLicense { get; set; } = string.Empty;

          [Required(ErrorMessage = "License Plate is required.")]
          [JsonPropertyOrder(2)]
          public string LicensePlate { get; set; } = string.Empty;

          [Required(ErrorMessage = "Brand is required.")]
          [JsonPropertyOrder(2)]
          public string Brand { get; set; } = string.Empty;

          [Required(ErrorMessage = "Color is required.")]
          [JsonPropertyOrder(2)]
          public string Color { get; set; } = string.Empty;

          [Required(ErrorMessage = "Model is required.")]
          [JsonPropertyOrder(2)]
          public string Model { get; set; } = string.Empty;

          [Required(ErrorMessage = "Vehicle Type ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid VehicleTypeId { get; set; }
     }
}