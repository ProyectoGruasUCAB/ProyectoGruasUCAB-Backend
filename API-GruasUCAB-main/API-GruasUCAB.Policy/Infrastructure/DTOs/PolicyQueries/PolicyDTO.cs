namespace API_GruasUCAB.Policy.Infrastructure.DTOs.PolicyQueries
{
     public class PolicyDTO
     {
          public Guid PolicyId { get; set; }
          public string PolicyNumber { get; set; } = string.Empty;
          public string PolicyName { get; set; } = string.Empty;
          public float PolicyCoverageAmount { get; set; }
          public int PolicyCoverageKm { get; set; }
          public float PolicyBaseAmount { get; set; }
          public float PolicyPriceKm { get; set; }
          public string PolicyIssueDate { get; set; } = string.Empty;
          public string PolicyExpirationDate { get; set; } = string.Empty;
          public Guid PolicyClientId { get; set; }
     }
}