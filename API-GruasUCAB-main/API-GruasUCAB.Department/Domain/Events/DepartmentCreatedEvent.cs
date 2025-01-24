namespace API_GruasUCAB.Department.Domain.Events
{
     public class DepartmentCreatedEvent : IDomainEvent
     {
          public DepartmentId DepartmentId { get; }
          public DepartmentName DepartmentName { get; }
          public DepartmentDescription DepartmentDescription { get; }
          public DateTime Timestamp { get; }

          public DepartmentCreatedEvent(DepartmentId departmentId, DepartmentName departmentName, DepartmentDescription departmentDescription)
          {
               DepartmentId = departmentId ?? throw new ArgumentNullException(nameof(departmentId), "DepartmentId cannot be null.");
               DepartmentName = departmentName ?? throw new ArgumentNullException(nameof(departmentName), "DepartmentName cannot be null.");
               DepartmentDescription = departmentDescription ?? throw new ArgumentNullException(nameof(departmentDescription), "DepartmentDescription cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => DepartmentId.ToString();
          public string Name => nameof(DepartmentCreatedEvent);
          public object Context => this;
     }
}