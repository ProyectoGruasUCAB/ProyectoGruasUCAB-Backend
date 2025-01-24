namespace API_GruasUCAB.Vehicle.Infrastructure.DTOs.VehicleQueries
{
     public class VehicleDTO
     {
          public Guid VehicleId { get; set; }
          public Guid? DriverId { get; set; }
          public Guid SupplierId { get; set; }
          public string CivilLiability { get; set; } = string.Empty;
          public string CivilLiabilityExpirationDate { get; set; } = string.Empty;
          public string TrafficLicense { get; set; } = string.Empty;
          public string LicensePlate { get; set; } = string.Empty;
          public string Brand { get; set; } = string.Empty;
          public string Color { get; set; } = string.Empty;
          public string Model { get; set; } = string.Empty;
          public Guid VehicleTypeId { get; set; }
     }
}