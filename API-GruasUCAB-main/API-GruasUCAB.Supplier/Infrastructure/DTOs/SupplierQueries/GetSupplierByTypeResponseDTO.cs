namespace API_GruasUCAB.Supplier.Infrastructure.DTOs.SupplierQueries
{
     public class GetSupplierByTypeResponseDTO
     {
          public List<SupplierDTO> Suppliers { get; set; } = new List<SupplierDTO>();
     }
}