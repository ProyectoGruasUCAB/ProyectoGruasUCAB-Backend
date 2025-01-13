namespace API_GruasUCAB.Supplier.Infrastructure.DTOs.CreateSupplier
{
     public class CreateSupplierRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "User ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid UserId { get; set; }

          [Required(ErrorMessage = "Name is required.")]
          [JsonPropertyOrder(2)]
          public string Name { get; set; } = string.Empty;

          [Required(ErrorMessage = "Type is required.")]
          [JsonPropertyOrder(2)]
          public string Type { get; set; } = string.Empty;
     }
}