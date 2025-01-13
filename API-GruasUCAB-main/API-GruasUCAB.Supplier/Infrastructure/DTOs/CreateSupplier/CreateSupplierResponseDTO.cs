namespace API_GruasUCAB.Supplier.Infrastructure.DTOs.CreateSupplier
{
     public class CreateSupplierResponseDTO : BaseResponseDTO
     {
          [Required(ErrorMessage = "Supplier ID is required.")]
          [JsonPropertyOrder(2)]
          public Guid SupplierId { get; set; }
     }
}