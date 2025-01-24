namespace API_GruasUCAB.Supplier.Infrastructure.DTOs.UpdateSupplier
{
     public class UpdateSupplierResponseDTO : BaseResponseDTO
     {
          [JsonPropertyOrder(2)]
          public Guid SupplierId { get; set; }

          [JsonPropertyOrder(2)]
          public string? Name { get; set; } = string.Empty;

          [JsonPropertyOrder(2)]
          public string? Type { get; set; } = string.Empty;
     }
}