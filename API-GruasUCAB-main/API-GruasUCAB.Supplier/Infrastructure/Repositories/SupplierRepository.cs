namespace API_GruasUCAB.Supplier.Infrastructure.Repositories
{
     public class SupplierRepository : ISupplierRepository
     {
          private readonly SupplierDbContext _context;
          private readonly IMapper _mapper;

          public SupplierRepository(SupplierDbContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }

          public async Task<List<SupplierDTO>> GetAllSuppliersAsync()
          {
               var suppliers = await _context.Suppliers.ToListAsync();
               return _mapper.Map<List<SupplierDTO>>(suppliers);
          }

          public async Task<SupplierDTO> GetSupplierByIdAsync(Guid id)
          {
               var supplier = await _context.Suppliers.FindAsync(new SupplierId(id));
               if (supplier == null)
               {
                    throw new KeyNotFoundException($"Supplier with ID {id} not found.");
               }

               return _mapper.Map<SupplierDTO>(supplier);
          }

          public async Task<List<SupplierDTO>> GetSuppliersByTypeAsync(string type)
          {
               if (!Enum.TryParse(type, out SupplierTypeEnum typeEnum))
               {
                    throw new ArgumentException($"Invalid supplier type: {type}");
               }

               var suppliers = await _context.Suppliers.ToListAsync();

               var filteredSuppliers = suppliers
                   .AsEnumerable()
                   .Where(s => s.Type.Value == typeEnum)
                   .ToList();

               if (!filteredSuppliers.Any())
               {
                    throw new KeyNotFoundException($"No suppliers with type '{type}' found.");
               }

               return _mapper.Map<List<SupplierDTO>>(filteredSuppliers);
          }


          public async Task<List<SupplierDTO>> GetSuppliersByNameAsync(string name)
          {
               var suppliers = await _context.Suppliers
                   .ToListAsync();

               var filteredSuppliers = suppliers
                   .Where(s => s.Name.Value.ToLower().Contains(name.ToLower()))
                   .ToList();

               if (!filteredSuppliers.Any())
               {
                    throw new KeyNotFoundException($"No suppliers with name containing '{name}' found.");
               }

               return _mapper.Map<List<SupplierDTO>>(filteredSuppliers);
          }

          public async Task AddSupplierAsync(SupplierDTO supplierDto)
          {
               var supplier = _mapper.Map<Domain.AggregateRoot.Supplier>(supplierDto);
               _context.Suppliers.Add(supplier);
               await _context.SaveChangesAsync();
          }

          public async Task UpdateSupplierAsync(SupplierDTO supplierDto)
          {
               var existingSupplier = await _context.Suppliers.FindAsync(new SupplierId(supplierDto.SupplierId));
               if (existingSupplier == null)
               {
                    throw new KeyNotFoundException($"Supplier with ID {supplierDto.SupplierId} not found.");
               }

               _mapper.Map(supplierDto, existingSupplier);
               await _context.SaveChangesAsync();
          }
     }
}