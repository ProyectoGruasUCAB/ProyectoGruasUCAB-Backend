namespace API_GruasUCAB.Users.Domain.Events
{
     public class DepartmentIdChangedEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public DepartmentId NewDepartmentId { get; }
          public DateTime Timestamp { get; }

          public DepartmentIdChangedEvent(UserId userId, DepartmentId newDepartmentId)
          {
               UserId = userId ?? throw new ArgumentNullException(nameof(userId), "UserId cannot be null.");
               NewDepartmentId = newDepartmentId ?? throw new ArgumentNullException(nameof(newDepartmentId), "NewDepartmentId cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => UserId.ToString();
          public string Name => nameof(DepartmentIdChangedEvent);
          public object Context => this;
     }
}