namespace API_GruasUCAB.Database.DepartmentWorker.Entities
{
     public class DepartmentWorker
     {
          public UserId WorkerId { get; private set; }
          public DepartmentId DepartmentId { get; private set; }

          // Propiedades de navegación
          public Worker Worker { get; private set; } = null!;
          public Department.Domain.AggregateRoot.Department Department { get; private set; } = null!;

          public DepartmentWorker(UserId workerId, DepartmentId departmentId)
          {
               WorkerId = workerId ?? throw new ArgumentNullException(nameof(workerId));
               DepartmentId = departmentId ?? throw new ArgumentNullException(nameof(departmentId));
          }
     }
}