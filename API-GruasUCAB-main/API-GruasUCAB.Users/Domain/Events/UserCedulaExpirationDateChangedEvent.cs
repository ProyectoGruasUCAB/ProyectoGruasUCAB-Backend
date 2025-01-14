namespace API_GruasUCAB.Users.Domain.Events
{
     public class UserCedulaExpirationDateChangedEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public UserCedulaExpirationDate NewCedulaExpirationDate { get; }
          public DateTime Timestamp { get; }
          public string DispatcherId => UserId.ToString();

          public UserCedulaExpirationDateChangedEvent(UserId userId, UserCedulaExpirationDate newCedulaExpirationDate)
          {
               UserId = userId;
               NewCedulaExpirationDate = newCedulaExpirationDate;
               Timestamp = DateTime.UtcNow;
          }

          public string Name => nameof(UserCedulaExpirationDateChangedEvent);
          public object Context => this;
     }
}