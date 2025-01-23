namespace API_GruasUCAB.Users.Domain.Events
{
     public class UserDriverLicenseExpirationDateChangedEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public UserDriverLicenseExpirationDate NewDriverLicenseExpirationDate { get; }
          public DateTime Timestamp { get; }
          public string DispatcherId => UserId.ToString();

          public UserDriverLicenseExpirationDateChangedEvent(UserId userId, UserDriverLicenseExpirationDate newDriverLicenseExpirationDate)
          {
               UserId = userId ?? throw new ArgumentNullException(nameof(userId), "UserId cannot be null.");
               NewDriverLicenseExpirationDate = newDriverLicenseExpirationDate ?? throw new ArgumentNullException(nameof(newDriverLicenseExpirationDate), "NewDriverLicenseExpirationDate cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string Name => nameof(UserDriverLicenseExpirationDateChangedEvent);
          public object Context => this;
     }
}