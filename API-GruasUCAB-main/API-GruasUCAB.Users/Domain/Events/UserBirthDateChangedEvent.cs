namespace API_GruasUCAB.Users.Domain.Events
{
     public class UserBirthDateChangedEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public UserBirthDate NewBirthDate { get; }
          public DateTime Timestamp { get; }
          public string DispatcherId => UserId.ToString();

          public UserBirthDateChangedEvent(UserId userId, UserBirthDate newBirthDate)
          {
               UserId = userId;
               NewBirthDate = newBirthDate;
               Timestamp = DateTime.UtcNow;
          }

          public string Name => nameof(UserBirthDateChangedEvent);
          public object Context => this;
     }
}