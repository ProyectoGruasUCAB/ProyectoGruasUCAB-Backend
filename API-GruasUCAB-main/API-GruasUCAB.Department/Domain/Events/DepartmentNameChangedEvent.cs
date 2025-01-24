namespace API_GruasUCAB.Department.Domain.Events
{
     public class DepartmentNameChangedEvent : IDomainEvent
     {
          public DepartmentId DepartmentId { get; }
          public DepartmentName NewName { get; }
          public DateTime Timestamp { get; }

          public DepartmentNameChangedEvent(DepartmentId departmentId, DepartmentName newName)
          {
               DepartmentId = departmentId ?? throw new ArgumentNullException(nameof(departmentId), "DepartmentId cannot be null.");
               NewName = newName ?? throw new ArgumentNullException(nameof(newName), "NewName cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => DepartmentId.ToString();
          public string Name => nameof(DepartmentNameChangedEvent);
          public object Context => this;
     }
}