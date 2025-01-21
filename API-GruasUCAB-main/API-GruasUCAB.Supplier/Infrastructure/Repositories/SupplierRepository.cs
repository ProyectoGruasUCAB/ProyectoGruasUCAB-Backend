using API_GruasUCAB.Supplier.Domain.AggregateRoot;
using API_GruasUCAB.Supplier.Infrastructure.Database;
using API_GruasUCAB.Supplier.Infrastructure.DTOs.SupplierQueries;
using API_GruasUCAB.Supplier.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace API_GruasUCAB.Supplier.Infrastructure.Repositories
{
     public class SupplierRepository : ISupplierRepository
     {
          private readonly SupplierDbContext _context;

          public SupplierRepository(SupplierDbContext context)
          {
               _context = context;
          }

          public async Task<List<SupplierDTO>> GetAllSuppliersAsync()
          {
               return await _context.Suppliers
                   .Select(s => s.ToDTO())
                   .ToListAsync();
          }

          public async Task<SupplierDTO> GetSupplierByIdAsync(Guid id)
          {
               var supplier = await _context.Suppliers
                   .FirstOrDefaultAsync(s => s.Id == new SupplierId(id));

               if (supplier == null)
               {
                    throw new KeyNotFoundException($"Supplier with ID {id} not found.");
               }

               return supplier.ToDTO();
          }

          public async Task<List<SupplierDTO>> GetSuppliersByTypeAsync(string type)
          {
               if (!Enum.TryParse(type, out SupplierTypeEnum typeEnum))
               {
                    throw new ArgumentException($"Invalid supplier type: {type}");
               }

               var suppliers = await _context.Suppliers
                   .ToListAsync();

               var filteredSuppliers = suppliers
                   .Where(s => s.Type.Value == typeEnum)
                   .Select(s => s.ToDTO())
                   .ToList();

               if (!filteredSuppliers.Any())
               {
                    throw new KeyNotFoundException($"No suppliers with type '{type}' found.");
               }

               return filteredSuppliers;
          }

          public async Task AddSupplierAsync(SupplierDTO supplierDto)
          {
               var supplier = supplierDto.ToEntity();

               _context.Suppliers.Add(supplier);
               await _context.SaveChangesAsync();
          }

          public async Task UpdateSupplierAsync(SupplierDTO supplierDto)
          {
               var supplier = await _context.Suppliers
                   .FirstOrDefaultAsync(s => s.Id == new SupplierId(supplierDto.SupplierId));

               if (supplier == null)
               {
                    throw new KeyNotFoundException($"Supplier with ID {supplierDto.SupplierId} not found.");
               }

               supplier.ChangeName(new SupplierName(supplierDto.Name));
               supplier.ChangeType(new SupplierType(Enum.Parse<SupplierTypeEnum>(supplierDto.Type)));

               _context.Suppliers.Update(supplier);
               await _context.SaveChangesAsync();
          }
     }
}