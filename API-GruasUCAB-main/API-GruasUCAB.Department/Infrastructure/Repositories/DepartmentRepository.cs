using API_GruasUCAB.Department.Domain.AggregateRoot;
using API_GruasUCAB.Department.Infrastructure.Database;
using API_GruasUCAB.Department.Infrastructure.DTOs.DepartmentQueries;
using API_GruasUCAB.Department.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace API_GruasUCAB.Department.Infrastructure.Repositories
{
     public class DepartmentRepository : IDepartmentRepository
     {
          private readonly DepartmentDbContext _context;

          public DepartmentRepository(DepartmentDbContext context)
          {
               _context = context;
          }

          public async Task<List<DepartmentDTO>> GetAllDepartmentsAsync()
          {
               return await _context.Departments
                   .Select(d => d.ToDTO())
                   .ToListAsync();
          }

          public async Task<DepartmentDTO> GetDepartmentByIdAsync(Guid id)
          {
               var department = await _context.Departments
                   .FirstOrDefaultAsync(d => d.Id == new DepartmentId(id));

               if (department == null)
               {
                    throw new KeyNotFoundException($"Department with ID {id} not found.");
               }

               return department.ToDTO();
          }

          public async Task<DepartmentDTO> GetDepartmentByNameAsync(string name)
          {
               var departments = await _context.Departments
                   .ToListAsync();

               var department = departments
                   .Where(d => d.Name.Value.ToLower().Contains(name.ToLower()))
                   .Select(d => d.ToDTO())
                   .FirstOrDefault();

               if (department == null)
               {
                    throw new KeyNotFoundException($"Department with name {name} not found.");
               }

               return department;
          }

          public async Task AddDepartmentAsync(DepartmentDTO departmentDto)
          {
               var department = departmentDto.ToEntity();

               _context.Departments.Add(department);
               await _context.SaveChangesAsync();
          }

          public async Task UpdateDepartmentAsync(DepartmentDTO departmentDto)
          {
               var department = await _context.Departments
                   .FirstOrDefaultAsync(d => d.Id == new DepartmentId(departmentDto.DepartmentId));

               if (department == null)
               {
                    throw new KeyNotFoundException($"Department with ID {departmentDto.DepartmentId} not found.");
               }

               department.ChangeName(new DepartmentName(departmentDto.Name));
               department.ChangeDescription(new DepartmentDescription(departmentDto.Descripcion));

               _context.Departments.Update(department);
               await _context.SaveChangesAsync();
          }
     }
}