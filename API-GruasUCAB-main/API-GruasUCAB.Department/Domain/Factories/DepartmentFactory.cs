namespace API_GruasUCAB.Department.Domain.Factories
{
     public class DepartmentFactory : IDepartmentFactory
     {
          private readonly IDepartmentRepository _departmentRepository;

          public DepartmentFactory(IDepartmentRepository departmentRepository)
          {
               _departmentRepository = departmentRepository;
          }

          public AggregateRoot.Department CreateDepartment(
              DepartmentId id,
              DepartmentName name,
              DepartmentDescription description)
          {
               return new AggregateRoot.Department(id, name, description);
          }

          public async Task<AggregateRoot.Department> GetDepartmentById(DepartmentId id)
          {
               var departmentDTO = await _departmentRepository.GetDepartmentByIdAsync(id.Id);
               return new AggregateRoot.Department(
                   new DepartmentId(departmentDTO.DepartmentId),
                   new DepartmentName(departmentDTO.Name),
                   new DepartmentDescription(departmentDTO.Descripcion)
               );
          }
     }
}