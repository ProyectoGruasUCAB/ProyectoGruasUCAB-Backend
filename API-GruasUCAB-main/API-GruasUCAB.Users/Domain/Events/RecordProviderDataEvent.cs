namespace API_GruasUCAB.Users.Domain.Events
{
     public class RecordProviderDataEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public UserName UserName { get; }
          public UserEmail Email { get; }
          public UserPhone Phone { get; }
          public UserBirthDate BirthDate { get; }
          public SupplierId SupplierId { get; }

          public RecordProviderDataEvent(UserId userId, UserName userName, UserEmail email, UserPhone phone, UserBirthDate birthDate, SupplierId supplierId)
          {
               UserId = userId ?? throw new ArgumentNullException(nameof(userId), "UserId cannot be null.");
               UserName = userName ?? throw new ArgumentNullException(nameof(userName), "UserName cannot be null.");
               Email = email ?? throw new ArgumentNullException(nameof(email), "Email cannot be null.");
               Phone = phone ?? throw new ArgumentNullException(nameof(phone), "Phone cannot be null.");
               BirthDate = birthDate ?? throw new ArgumentNullException(nameof(birthDate), "BirthDate cannot be null.");
               SupplierId = supplierId ?? throw new ArgumentNullException(nameof(supplierId), "SupplierId cannot be null.");
          }

          public string DispatcherId => UserId.ToString();
          public string Name => nameof(RecordProviderDataEvent);
          public DateTime Timestamp { get; } = DateTime.UtcNow;
          public object Context => this;
     }
}