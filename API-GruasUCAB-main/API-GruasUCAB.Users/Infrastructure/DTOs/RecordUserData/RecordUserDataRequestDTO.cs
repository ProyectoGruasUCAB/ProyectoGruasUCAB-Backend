namespace API_GruasUCAB.Users.Infrastructure.DTOs.RecordUserData
{
     public class RecordUserDataRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "Id is required.")]
          [JsonPropertyOrder(2)]
          public required Guid UserId { get; set; }

          [Required(ErrorMessage = "Name is required.")]
          [JsonPropertyOrder(2)]
          public required string Name { get; set; }

          [Required(ErrorMessage = "Phone is required.")]
          [JsonPropertyOrder(2)]
          public required string Phone { get; set; }

          [Required(ErrorMessage = "Cedula is required.")]
          [JsonPropertyOrder(2)]
          public required string Cedula { get; set; }

          [Required(ErrorMessage = "Roles are required.")]
          [JsonPropertyOrder(2)]
          public required string Role { get; set; }

          [Required(ErrorMessage = "Birth date is required.")]
          [JsonPropertyOrder(2)]
          public required string BirthDate { get; set; }

          [JsonPropertyOrder(2)]
          public string? CedulaExpirationDate { get; set; }

          [JsonPropertyOrder(2)]
          public string? MedicalCertificate { get; set; }

          [JsonPropertyOrder(2)]
          public string? MedicalCertificateExpirationDate { get; set; }

          [JsonPropertyOrder(2)]
          public string? DriverLicense { get; set; }

          [JsonPropertyOrder(2)]
          public string? DriverLicenseExpirationDate { get; set; }

          [JsonPropertyOrder(2)]
          public string? Position { get; set; }
     }
}