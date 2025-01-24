namespace API_GruasUCAB.Users.Infrastructure.DTOs.RecordUserData
{
     public class RecordUserDataRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "Id is required.")]
          [JsonPropertyOrder(2)]
          public required Guid UserId { get; set; }

          [Required(ErrorMessage = "Name is required.")]
          [JsonPropertyOrder(2)]
          public required string Name { get; set; } = string.Empty;

          [Required(ErrorMessage = "Phone is required.")]
          [JsonPropertyOrder(2)]
          public required string Phone { get; set; } = string.Empty;

          [Required(ErrorMessage = "Cedula is required.")]
          [JsonPropertyOrder(2)]
          public required string Cedula { get; set; } = string.Empty;

          [Required(ErrorMessage = "Roles are required.")]
          [JsonPropertyOrder(2)]
          public required string Role { get; set; }

          [Required(ErrorMessage = "Birth date is required.")]
          [JsonPropertyOrder(2)]
          public required string BirthDate { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? MedicalCertificate { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? MedicalCertificateExpirationDate { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? DriverLicense { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? DriverLicenseExpirationDate { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? Position { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public Guid? WorkplaceId { get; set; }

          [JsonPropertyOrder(2)]
          public string? Token { get; set; } = string.Empty;
     }
}