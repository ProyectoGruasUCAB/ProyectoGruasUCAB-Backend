namespace API_GruasUCAB.Users.Domain.Events
{
     public class RecordWorkerDataEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public UserName UserName { get; }
          public UserEmail Email { get; }
          public UserPhone Phone { get; }
          public UserBirthDate BirthDate { get; }
          public UserPosition Position { get; }
          public DepartmentId DepartmentId { get; }

          public RecordWorkerDataEvent(UserId userId, UserName userName, UserEmail email, UserPhone phone, UserBirthDate birthDate, UserPosition position, DepartmentId departmentId)
          {
               UserId = userId ?? throw new ArgumentNullException(nameof(userId), "UserId cannot be null.");
               UserName = userName ?? throw new ArgumentNullException(nameof(userName), "UserName cannot be null.");
               Email = email ?? throw new ArgumentNullException(nameof(email), "Email cannot be null.");
               Phone = phone ?? throw new ArgumentNullException(nameof(phone), "Phone cannot be null.");
               BirthDate = birthDate ?? throw new ArgumentNullException(nameof(birthDate), "BirthDate cannot be null.");
               Position = position ?? throw new ArgumentNullException(nameof(position), "Position cannot be null.");
               DepartmentId = departmentId ?? throw new ArgumentNullException(nameof(departmentId), "DepartmentId cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => UserId.ToString();
          public string Name => nameof(RecordWorkerDataEvent);
          public DateTime Timestamp { get; }
          public object Context => this;
     }
}