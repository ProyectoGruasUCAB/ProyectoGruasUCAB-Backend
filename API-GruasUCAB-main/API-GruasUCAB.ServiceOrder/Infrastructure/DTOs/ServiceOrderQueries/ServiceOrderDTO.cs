namespace API_GruasUCAB.ServiceOrder.Infrastructure.DTOs.ServiceOrderQueries
{
     public class ServiceOrderDTO
     {
          public Guid ServiceOrderId { get; set; }
          public string StatusServiceOrder { get; set; } = string.Empty;
          public string IncidentDescription { get; set; } = string.Empty;
          public double InitialLocationDriverLat { get; set; }
          public double InitialLocationDriverLon { get; set; }
          public double IncidentLocationLat { get; set; }
          public double IncidentLocationLon { get; set; }
          public double IncidentLocationEndLat { get; set; }
          public double IncidentLocationEndLon { get; set; }
          public float IncidentDistance { get; set; }
          public string CustomerVehicleDescription { get; set; } = string.Empty;
          public float IncidentCost { get; set; }
          public Guid PolicyId { get; set; }
          public string IncidentDate { get; set; } = string.Empty;
          public Guid VehicleId { get; set; }
          public Guid DriverId { get; set; }
          public Guid CustomerId { get; set; }
          public Guid OperatorId { get; set; }
          public Guid ServiceFeeId { get; set; }
     }
}