namespace API_GruasUCAB.Users.Domain.Events
{
     public class UserDriverLicenseChangedEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public UserDriverLicense NewDriverLicense { get; }
          public DateTime Timestamp { get; }
          public string DispatcherId => UserId.ToString();

          public UserDriverLicenseChangedEvent(UserId userId, UserDriverLicense newDriverLicense)
          {
               UserId = userId;
               NewDriverLicense = newDriverLicense;
               Timestamp = DateTime.UtcNow;
          }

          public string Name => nameof(UserDriverLicenseChangedEvent);
          public object Context => this;
     }
}