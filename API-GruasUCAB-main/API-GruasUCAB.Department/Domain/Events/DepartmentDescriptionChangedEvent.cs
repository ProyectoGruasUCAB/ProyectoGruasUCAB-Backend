namespace API_GruasUCAB.Department.Domain.Events
{
     public class DepartmentDescriptionChangedEvent : IDomainEvent
     {
          public DepartmentId DepartmentId { get; }
          public DepartmentDescription NewDescription { get; }
          public DateTime Timestamp { get; }

          public DepartmentDescriptionChangedEvent(DepartmentId departmentId, DepartmentDescription newDescription)
          {
               DepartmentId = departmentId ?? throw new ArgumentNullException(nameof(departmentId), "DepartmentId cannot be null.");
               NewDescription = newDescription ?? throw new ArgumentNullException(nameof(newDescription), "NewDescription cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => DepartmentId.ToString();
          public string Name => nameof(DepartmentDescriptionChangedEvent);
          public object Context => this;
     }
}