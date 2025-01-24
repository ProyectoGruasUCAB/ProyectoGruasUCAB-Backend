namespace API_GruasUCAB.Policy.Infrastructure.DTOs.CreatePolicy
{
     public class CreatePolicyRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Name is required.")]
          [JsonPropertyOrder(2)]
          public string Name { get; set; } = string.Empty;

          [Required(ErrorMessage = "Coverage amount is required.")]
          [JsonPropertyOrder(2)]
          public decimal CoverageAmount { get; set; }

          [Required(ErrorMessage = "Coverage kilometers is required.")]
          [JsonPropertyOrder(2)]
          public int CoverageKm { get; set; }

          [Required(ErrorMessage = "Base amount is required.")]
          [JsonPropertyOrder(2)]
          public decimal BaseAmount { get; set; }

          [Required(ErrorMessage = "Price per kilometer is required.")]
          [JsonPropertyOrder(2)]
          public decimal PriceKm { get; set; }

          [Required(ErrorMessage = "Client ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid ClientId { get; set; }
     }
}