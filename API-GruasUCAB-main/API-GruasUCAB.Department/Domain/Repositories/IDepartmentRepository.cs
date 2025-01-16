namespace API_GruasUCAB.Department.Domain.Repositories
{
     public interface IDepartmentRepository
     {
          Task<List<DepartmentDTO>> GetAllDepartmentsAsync();
          Task<DepartmentDTO> GetDepartmentByIdAsync(Guid departmentid);
          Task<DepartmentDTO> GetDepartmentByNameAsync(string name);
          Task AddDepartmentAsync(DepartmentDTO department);
          Task UpdateDepartmentAsync(DepartmentDTO department);
     }
}