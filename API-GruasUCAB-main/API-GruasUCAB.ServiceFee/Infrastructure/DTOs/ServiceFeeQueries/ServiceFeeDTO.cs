namespace API_GruasUCAB.ServiceFee.Infrastructure.DTOs.ServiceFeeQueries
{
     public class ServiceFeeDTO
     {
          public Guid ServiceFeeId { get; set; }
          public string Name { get; set; } = string.Empty;
          public string Description { get; set; } = string.Empty;
          public float Price { get; set; }
          public float PriceKm { get; set; }
          public int Radius { get; set; }
     }
}