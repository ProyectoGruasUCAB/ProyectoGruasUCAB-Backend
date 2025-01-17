namespace API_GruasUCAB.Policy.Infrastructure.DTOs.PolicyQueries
{
     public class PolicyDTO
     {
          public Guid PolicyId { get; set; }
          public string Number { get; set; } = string.Empty;
          public string Name { get; set; } = string.Empty;
          public float CoverageAmount { get; set; }
          public int CoverageKm { get; set; }
          public float BaseAmount { get; set; }
          public float PriceKm { get; set; }
          public string IssueDate { get; set; } = string.Empty;
          public string ExpirationDate { get; set; } = string.Empty;
          public Guid ClientId { get; set; }
     }
}