namespace API_GruasUCAB.ServiceOrder.Infrastructure.DTOs.ServiceOrderQueries
{
     public class ServiceOrderDTO
     {
          public Guid ServiceOrderId { get; set; }
          public string IncidentDescription { get; set; } = string.Empty;
          public float InitialLocationDriverLatitude { get; set; }
          public float InitialLocationDriverLongitude { get; set; }
          public float IncidentLocationLatitude { get; set; }
          public float IncidentLocationLongitude { get; set; }
          public float IncidentLocationEndLatitude { get; set; }
          public float IncidentLocationEndLongitude { get; set; }
          public float IncidentDistance { get; set; }
          public string CustomerVehicleDescription { get; set; } = string.Empty;
          public decimal IncidentCost { get; set; }
          public Guid PolicyId { get; set; }
          public string StatusServiceOrder { get; set; } = string.Empty;
          public string IncidentDate { get; set; } = string.Empty;
          public Guid VehicleId { get; set; }
          public Guid DriverId { get; set; }
          public Guid CustomerId { get; set; }
          public Guid OperatorId { get; set; }
          public Guid ServiceFeeId { get; set; }
     }
}