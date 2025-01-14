namespace API_GruasUCAB.Department.Domain.Factories
{
     public class DepartmentFactory : IDepartmentFactory
     {
          public AggregateRoot.Department CreateDepartment(
              DepartmentId id,
              DepartmentName name,
              DepartmentDescription description)
          {
               return new AggregateRoot.Department(id, name, description);
          }

          public async Task<AggregateRoot.Department> GetDepartmentById(DepartmentId id)
          {
               // Implementa la lógica para obtener el departamento por su ID
               // Esto puede involucrar una llamada a un repositorio o una base de datos
               // Aquí se usa Task.FromResult como un ejemplo de implementación asincrónica
               return await Task.FromResult(new AggregateRoot.Department(id, new DepartmentName("Example"), new DepartmentDescription("Example Description")));
          }
     }
}