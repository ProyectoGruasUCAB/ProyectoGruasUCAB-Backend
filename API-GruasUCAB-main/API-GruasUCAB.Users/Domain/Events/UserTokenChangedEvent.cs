namespace API_GruasUCAB.Users.Domain.Events
{
     public class UserTokenChangedEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public UserToken NewToken { get; }
          public DateTime Timestamp { get; }
          public string DispatcherId => UserId.ToString();

          public UserTokenChangedEvent(UserId userId, UserToken newToken)
          {
               UserId = userId;
               NewToken = newToken;
               Timestamp = DateTime.UtcNow;
          }

          public string Name => nameof(UserTokenChangedEvent);
          public object Context => this;
     }
}