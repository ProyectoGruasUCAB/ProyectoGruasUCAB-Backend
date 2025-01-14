namespace API_GruasUCAB.Users.Domain.Events
{
     public class UserPhoneChangedEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public UserPhone NewPhone { get; }
          public DateTime Timestamp { get; }
          public string DispatcherId => UserId.ToString();

          public UserPhoneChangedEvent(UserId userId, UserPhone newPhone)
          {
               UserId = userId;
               NewPhone = newPhone;
               Timestamp = DateTime.UtcNow;
          }

          public string Name => nameof(UserPhoneChangedEvent);
          public object Context => this;
     }
}