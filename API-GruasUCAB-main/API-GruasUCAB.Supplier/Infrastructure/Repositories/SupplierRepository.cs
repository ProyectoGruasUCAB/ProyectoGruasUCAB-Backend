namespace API_GruasUCAB.Supplier.Infrastructure.Repositories
{
     public class SupplierRepository : ISupplierRepository
     {
          private readonly List<SupplierDTO> _suppliers;

          public SupplierRepository()
          {
               // Inicializar la lista con datos de ejemplo
               _suppliers = new List<SupplierDTO>
            {
                new SupplierDTO
                {
                    SupplierId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Supplier A",
                    Type = "Type1"
                },
                new SupplierDTO
                {
                    SupplierId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Supplier B",
                    Type = "Type2"
                },
                new SupplierDTO
                {
                    SupplierId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Supplier C",
                    Type = "Type3"
                }
            };
          }

          public async Task<List<SupplierDTO>> GetAllSuppliersAsync()
          {
               // Simulación de una llamada a la base de datos
               return await Task.FromResult(_suppliers);
          }

          public async Task<SupplierDTO> GetSupplierByIdAsync(Guid id)
          {
               // Simulación de una llamada a la base de datos
               var supplier = _suppliers.FirstOrDefault(s => s.SupplierId == id);
               if (supplier == null)
               {
                    throw new KeyNotFoundException($"Supplier with ID {id} not found.");
               }
               return await Task.FromResult(supplier);
          }

          public async Task<List<SupplierDTO>> GetSuppliersByTypeAsync(string type)
          {
               // Simulación de una llamada a la base de datos
               var suppliers = _suppliers.Where(s => s.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
               if (!suppliers.Any())
               {
                    throw new KeyNotFoundException($"No suppliers with type '{type}' found.");
               }
               return await Task.FromResult(suppliers);
          }

          public async Task AddSupplierAsync(SupplierDTO supplier)
          {
               // Simulación de una llamada a la base de datos
               _suppliers.Add(supplier);
               await Task.CompletedTask;
          }

          public async Task UpdateSupplierAsync(SupplierDTO supplier)
          {
               // Simulación de una llamada a la base de datos
               var existingSupplier = _suppliers.FirstOrDefault(s => s.SupplierId == supplier.SupplierId);
               if (existingSupplier == null)
               {
                    throw new KeyNotFoundException($"Supplier with ID {supplier.SupplierId} not found.");
               }

               existingSupplier.Name = supplier.Name;
               existingSupplier.Type = supplier.Type;

               await Task.CompletedTask;
          }
     }
}