namespace API_GruasUCAB.Vehicle.Infrastructure.DTOs.VehicleType
{
     public class CreateVehicleTypeResponseDTO : BaseResponseDTO
     {
          [Required(ErrorMessage = "Vehicle Type ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid VehicleTypeId { get; set; }
     }
}