namespace API_GruasUCAB.ServiceFee.Infrastructure.DTOs.CreateServiceFee
{
     public class CreateServiceFeeRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Name is required.")]
          [JsonPropertyOrder(2)]
          public string Name { get; set; } = string.Empty;

          [Required(ErrorMessage = "Description is required.")]
          [JsonPropertyOrder(2)]
          public string Description { get; set; } = string.Empty;

          [Required(ErrorMessage = "Price is required.")]
          [JsonPropertyOrder(2)]
          public float Price { get; set; }

          [Required(ErrorMessage = "PriceKm is required.")]
          [JsonPropertyOrder(2)]
          public float PriceKm { get; set; }

          [Required(ErrorMessage = "Radius is required.")]
          [JsonPropertyOrder(2)]
          public int Radius { get; set; }
     }
}