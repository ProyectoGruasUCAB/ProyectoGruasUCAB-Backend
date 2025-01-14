namespace API_GruasUCAB.Supplier.Infrastructure.DTOs.SupplierQueries
{
     public class SupplierDTO
     {
          public Guid SupplierId { get; set; }
          public string Name { get; set; } = string.Empty;
          public string Type { get; set; } = string.Empty;
     }
}