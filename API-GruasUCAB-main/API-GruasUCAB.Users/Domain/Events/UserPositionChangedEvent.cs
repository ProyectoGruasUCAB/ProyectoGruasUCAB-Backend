namespace API_GruasUCAB.Users.Domain.Events
{
     public class UserPositionChangedEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public UserPosition NewPosition { get; }
          public DateTime Timestamp { get; }
          public string DispatcherId => UserId.ToString();

          public UserPositionChangedEvent(UserId userId, UserPosition newPosition)
          {
               UserId = userId;
               NewPosition = newPosition;
               Timestamp = DateTime.UtcNow;
          }

          public string Name => nameof(UserPositionChangedEvent);
          public object Context => this;
     }
}