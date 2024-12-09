namespace API_GruasUCAB.Users.Domain.Events
{
     public class UserNameChangedEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public UserName NewName { get; }
          public DateTime Timestamp { get; }
          public string DispatcherId => UserId.Id;

          public UserNameChangedEvent(UserId userId, UserName newName)
          {
               UserId = userId;
               NewName = newName;
               Timestamp = DateTime.UtcNow;
          }

          public string Name => nameof(UserNameChangedEvent);
          public object Context => this;
     }
}