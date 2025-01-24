namespace API_GruasUCAB.ServiceOrder.Infrastructure.DTOs.UpdateServiceOrder
{
     public class UpdateServiceOrderRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Service Order ID is required.")]
          public Guid ServiceOrderId { get; set; }

          public string? IncidentDescription { get; set; } = string.Empty;

          public string? State { get; set; } = string.Empty;

          public double? InitialLocationDriverLat { get; set; }

          public double? InitialLocationDriverLon { get; set; }

          public double? IncidentLocationLat { get; set; }

          public double? IncidentLocationLon { get; set; }

          public double? IncidentLocationEndLat { get; set; }

          public double? IncidentLocationEndLon { get; set; }

          public float? IncidentDistance { get; set; }

          public string? CustomerVehicleDescription { get; set; } = string.Empty;

          public decimal? IncidentCost { get; set; }

          public Guid? PolicyId { get; set; }

          public Guid? VehicleId { get; set; }

          public Guid? DriverId { get; set; }

          public Guid? CustomerId { get; set; }

          public Guid? OperatorId { get; set; }

          public Guid? ServiceFeeId { get; set; }
     }
}