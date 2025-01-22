namespace API_GruasUCAB.Policy.Infrastructure.DTOs.PolicyQueries
{
     public class PolicyDTO
     {
          public Guid PolicyId { get; set; }
          public string Number { get; set; } = string.Empty;
          public string Name { get; set; } = string.Empty;
          public decimal CoverageAmount { get; set; }
          public int CoverageKm { get; set; }
          public decimal BaseAmount { get; set; }
          public decimal PriceKm { get; set; }
          public string IssueDate { get; set; } = string.Empty;
          public string ExpirationDate { get; set; } = string.Empty;
          public Guid ClientId { get; set; }
     }
}