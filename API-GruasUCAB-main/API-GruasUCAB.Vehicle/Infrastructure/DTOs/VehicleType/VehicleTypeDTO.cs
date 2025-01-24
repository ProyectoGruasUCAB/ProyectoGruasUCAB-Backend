namespace API_GruasUCAB.Vehicle.Infrastructure.DTOs.VehicleType
{
     public class VehicleTypeDTO
     {
          public Guid VehicleTypeId { get; set; }
          public string Name { get; set; } = string.Empty;
          public string Description { get; set; } = string.Empty;
     }
}