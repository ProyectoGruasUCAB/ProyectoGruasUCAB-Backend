namespace API_GruasUCAB.Department.Infrastructure.Repositories
{
     public class DepartmentRepository : IDepartmentRepository
     {
          private readonly DepartmentDbContext _context;
          private readonly IMapper _mapper;

          public DepartmentRepository(DepartmentDbContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }

          public async Task<List<DepartmentDTO>> GetAllDepartmentsAsync()
          {
               var departments = await _context.Departments.ToListAsync();
               return _mapper.Map<List<DepartmentDTO>>(departments);
          }

          public async Task<DepartmentDTO> GetDepartmentByIdAsync(Guid id)
          {
               var department = await _context.Departments
                   .FirstOrDefaultAsync(d => d.Id == new DepartmentId(id));

               if (department == null)
               {
                    throw new KeyNotFoundException($"Department with ID {id} not found.");
               }

               return _mapper.Map<DepartmentDTO>(department);
          }

          public async Task<DepartmentDTO> GetDepartmentByNameAsync(string name)
          {
               var departments = await _context.Departments.ToListAsync();

               var department = departments
                   .AsEnumerable()
                   .FirstOrDefault(d => d.Name.Value.ToLower() == name.ToLower());

               if (department == null)
               {
                    throw new KeyNotFoundException($"Department with name '{name}' not found.");
               }

               return _mapper.Map<DepartmentDTO>(department);
          }

          public async Task AddDepartmentAsync(DepartmentDTO departmentDto)
          {
               var department = _mapper.Map<Domain.AggregateRoot.Department>(departmentDto);
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

               _mapper.Map(departmentDto, department);
               await _context.SaveChangesAsync();
          }
     }
}