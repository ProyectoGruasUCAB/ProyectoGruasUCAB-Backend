namespace API_GruasUCAB.Users.Infrastructure.DTOs.DriverQueries
{
     public class DriverDTO
     {
          public Guid Id { get; set; }
          public string Name { get; set; } = string.Empty;
          public string UserEmail { get; set; } = string.Empty;
          public string Phone { get; set; } = string.Empty;
          public string Cedula { get; set; } = string.Empty;
          public string BirthDate { get; set; } = string.Empty;
          public string MedicalCertificate { get; set; } = string.Empty;
          public string MedicalCertificateExpirationDate { get; set; } = string.Empty;
          public string DriverLicense { get; set; } = string.Empty;
          public string DriverLicenseExpirationDate { get; set; } = string.Empty;
          public Guid SupplierId { get; set; }
     }
}