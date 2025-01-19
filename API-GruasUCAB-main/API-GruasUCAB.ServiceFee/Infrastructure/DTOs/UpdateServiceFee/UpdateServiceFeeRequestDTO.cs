namespace API_GruasUCAB.ServiceFee.Infrastructure.DTOs.UpdateServiceFee
{
     public class UpdateServiceFeeRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Service Fee ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid ServiceFeeId { get; set; }

          [JsonPropertyOrder(2)]
          public string? Name { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? Description { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public float? Price { get; set; }

          [JsonPropertyOrder(2)]
          public float? PriceKm { get; set; }

          [JsonPropertyOrder(2)]
          public int? Radius { get; set; }
     }
}