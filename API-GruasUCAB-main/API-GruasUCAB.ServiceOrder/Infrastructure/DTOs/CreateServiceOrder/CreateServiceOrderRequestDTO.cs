namespace API_GruasUCAB.ServiceOrder.Infrastructure.DTOs.CreateServiceOrder
{
     public class CreateServiceOrderRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Incident description is required.")]
          [JsonPropertyOrder(2)]
          public string IncidentDescription { get; set; } = string.Empty;

          [Required(ErrorMessage = "Initial status is required.")]
          [JsonPropertyOrder(2)]
          public string InitialStatus { get; set; } = string.Empty;

          [Required(ErrorMessage = "Initial location driver latitude is required.")]
          [JsonPropertyOrder(3)]
          public double InitialLocationDriverLatitude { get; set; }

          [Required(ErrorMessage = "Initial location driver longitude is required.")]
          [JsonPropertyOrder(4)]
          public double InitialLocationDriverLongitude { get; set; }

          [Required(ErrorMessage = "Incident location latitude is required.")]
          [JsonPropertyOrder(5)]
          public double IncidentLocationLatitude { get; set; }

          [Required(ErrorMessage = "Incident location longitude is required.")]
          [JsonPropertyOrder(6)]
          public double IncidentLocationLongitude { get; set; }

          [Required(ErrorMessage = "Incident location end latitude is required.")]
          [JsonPropertyOrder(7)]
          public double IncidentLocationEndLatitude { get; set; }

          [Required(ErrorMessage = "Incident location end longitude is required.")]
          [JsonPropertyOrder(8)]
          public double IncidentLocationEndLongitude { get; set; }

          [Required(ErrorMessage = "Incident distance is required.")]
          [JsonPropertyOrder(9)]
          public float IncidentDistance { get; set; }

          [Required(ErrorMessage = "Customer vehicle description is required.")]
          [JsonPropertyOrder(10)]
          public string CustomerVehicleDescription { get; set; } = string.Empty;

          [Required(ErrorMessage = "Incident cost is required.")]
          [JsonPropertyOrder(11)]
          public float IncidentCost { get; set; }

          [Required(ErrorMessage = "Policy ID is required.")]
          [JsonPropertyOrder(12)]
          public Guid PolicyId { get; set; }

          [Required(ErrorMessage = "Vehicle ID is required.")]
          [JsonPropertyOrder(15)]
          public Guid VehicleId { get; set; }

          [Required(ErrorMessage = "Driver ID is required.")]
          [JsonPropertyOrder(16)]
          public Guid DriverId { get; set; }

          [Required(ErrorMessage = "Customer ID is required.")]
          [JsonPropertyOrder(17)]
          public Guid CustomerId { get; set; }

          [Required(ErrorMessage = "Operator ID is required.")]
          [JsonPropertyOrder(18)]
          public Guid OperatorId { get; set; }

          [Required(ErrorMessage = "Service fee ID is required.")]
          [JsonPropertyOrder(19)]
          public Guid ServiceFeeId { get; set; }
     }
}