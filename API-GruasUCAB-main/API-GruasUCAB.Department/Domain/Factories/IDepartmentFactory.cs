namespace API_GruasUCAB.Department.Domain.Factories
{
     public interface IDepartmentFactory
     {
          AggregateRoot.Department CreateDepartment(
              DepartmentId id,
              DepartmentName name,
              DepartmentDescription description);

          Task<AggregateRoot.Department> GetDepartmentById(DepartmentId id);
     }
}