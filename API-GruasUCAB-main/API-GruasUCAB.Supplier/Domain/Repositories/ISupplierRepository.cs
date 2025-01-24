namespace API_GruasUCAB.Supplier.Domain.Repositories
{
     public interface ISupplierRepository
     {
          Task<List<SupplierDTO>> GetAllSuppliersAsync();
          Task<SupplierDTO> GetSupplierByIdAsync(Guid id);
          Task<List<SupplierDTO>> GetSuppliersByTypeAsync(string type);
          Task<List<SupplierDTO>> GetSuppliersByNameAsync(string name);
          Task AddSupplierAsync(SupplierDTO supplier);
          Task UpdateSupplierAsync(SupplierDTO supplier);
     }
}