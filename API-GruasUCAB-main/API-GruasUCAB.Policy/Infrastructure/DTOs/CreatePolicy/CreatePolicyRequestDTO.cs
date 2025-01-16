namespace API_GruasUCAB.Policy.Infrastructure.DTOs.CreatePolicy
{
     public class CreatePolicyRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Policy number is required.")]
          [JsonPropertyOrder(1)]
          public string PolicyNumber { get; set; } = string.Empty;

          [Required(ErrorMessage = "Policy name is required.")]
          [JsonPropertyOrder(2)]
          public string PolicyName { get; set; } = string.Empty;

          [Required(ErrorMessage = "Policy coverage amount is required.")]
          [JsonPropertyOrder(2)]
          public float PolicyCoverageAmount { get; set; }

          [Required(ErrorMessage = "Policy coverage kilometers is required.")]
          [JsonPropertyOrder(2)]
          public int PolicyCoverageKm { get; set; }

          [Required(ErrorMessage = "Policy base amount is required.")]
          [JsonPropertyOrder(2)]
          public float PolicyBaseAmount { get; set; }

          [Required(ErrorMessage = "Policy price per kilometer is required.")]
          [JsonPropertyOrder(2)]
          public float PolicyPriceKm { get; set; }

          [Required(ErrorMessage = "Policy issue date is required.")]
          [JsonPropertyOrder(2)]
          public string PolicyIssueDate { get; set; } = string.Empty;

          [Required(ErrorMessage = "Policy expiration date is required.")]
          [JsonPropertyOrder(2)]
          public string PolicyExpirationDate { get; set; } = string.Empty;

          [Required(ErrorMessage = "Policy client ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid PolicyClientId { get; set; }
     }
}