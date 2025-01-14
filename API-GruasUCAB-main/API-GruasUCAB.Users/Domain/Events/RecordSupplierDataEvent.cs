namespace API_GruasUCAB.Users.Domain.Events
{
     public class RecordSupplierDataEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public UserName UserName { get; }
          public UserEmail Email { get; }
          public UserPhone Phone { get; }
          public UserBirthDate BirthDate { get; }

          public RecordSupplierDataEvent(UserId userId, UserName userName, UserEmail email, UserPhone phone, UserBirthDate birthDate)
          {
               UserId = userId ?? throw new ArgumentNullException(nameof(userId), "UserId cannot be null.");
               UserName = userName ?? throw new ArgumentNullException(nameof(userName), "UserName cannot be null.");
               Email = email ?? throw new ArgumentNullException(nameof(email), "Email cannot be null.");
               Phone = phone ?? throw new ArgumentNullException(nameof(phone), "Phone cannot be null.");
               BirthDate = birthDate ?? throw new ArgumentNullException(nameof(birthDate), "BirthDate cannot be null.");
          }

          public string DispatcherId => UserId.ToString();
          public string Name => nameof(RecordSupplierDataEvent);
          public DateTime Timestamp { get; }
          public object Context => this;
     }
}