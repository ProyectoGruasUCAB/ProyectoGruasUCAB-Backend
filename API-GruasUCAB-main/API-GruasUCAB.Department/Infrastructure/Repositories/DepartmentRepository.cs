namespace API_GruasUCAB.Department.Infrastructure.Repositories
{
     public class DepartmentRepository : IDepartmentRepository
     {
          private readonly List<DepartmentDTO> _departments;

          public DepartmentRepository()
          {
               // Inicializar la lista con datos de ejemplo
               _departments = new List<DepartmentDTO>
            {
                new DepartmentDTO
                {
                    DepartmentId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "HR",
                    Descripcion = "Human Resources"
                },
                new DepartmentDTO
                {
                    DepartmentId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "IT",
                    Descripcion = "Information Technology"
                },
                new DepartmentDTO
                {
                    DepartmentId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Finance",
                    Descripcion = "Finance Department"
                }
            };
          }

          public async Task<List<DepartmentDTO>> GetAllDepartmentsAsync()
          {
               // Simulación de una llamada a la base de datos
               return await Task.FromResult(_departments);
          }

          public async Task<DepartmentDTO> GetDepartmentByIdAsync(Guid id)
          {
               // Simulación de una llamada a la base de datos
               var department = _departments.FirstOrDefault(d => d.DepartmentId == id);
               if (department == null)
               {
                    throw new KeyNotFoundException($"Department with ID {id} not found.");
               }
               return await Task.FromResult(department);
          }

          public async Task<DepartmentDTO> GetDepartmentByNameAsync(string name)
          {
               // Simulación de una llamada a la base de datos
               var department = _departments.FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
               if (department == null)
               {
                    throw new KeyNotFoundException($"Department with name {name} not found.");
               }
               return await Task.FromResult(department);
          }
     }
}