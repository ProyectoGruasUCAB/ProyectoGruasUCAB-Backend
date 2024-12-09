namespace API_GruasUCAB.Users.Infrastructure.DTOs.UpdateUser
{
     public class UpdateRecordUserDataRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "Id is required.")]
          [JsonPropertyOrder(2)]
          public required Guid Id { get; set; }

          [Required(ErrorMessage = "Role is required.")]
          [JsonPropertyOrder(2)]
          public required string Role { get; set; }

          [JsonPropertyOrder(2)]
          public string? Name { get; set; }

          [JsonPropertyOrder(2)]
          public string? Phone { get; set; }

          [JsonPropertyOrder(2)]
          public string? BirthDate { get; set; }

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