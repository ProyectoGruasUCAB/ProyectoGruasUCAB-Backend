namespace API_GruasUCAB.Users.Infrastructure.DTOs.UpdateUser
{
     public class UpdateRecordUserDataRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "Id is required.")]
          [JsonPropertyOrder(2)]
          public required Guid UserId { get; set; }

          [Required(ErrorMessage = "Role is required.")]
          [JsonPropertyOrder(2)]
          public string Role { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? Name { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? Phone { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? BirthDate { get; set; } = string.Empty;

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
     }
}