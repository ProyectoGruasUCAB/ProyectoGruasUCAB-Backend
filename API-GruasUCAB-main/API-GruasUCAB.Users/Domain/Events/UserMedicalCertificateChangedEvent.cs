namespace API_GruasUCAB.Users.Domain.Events
{
     public class UserMedicalCertificateChangedEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public UserMedicalCertificate NewMedicalCertificate { get; }
          public DateTime Timestamp { get; }
          public string DispatcherId => UserId.Id;

          public UserMedicalCertificateChangedEvent(UserId userId, UserMedicalCertificate newMedicalCertificate)
          {
               UserId = userId;
               NewMedicalCertificate = newMedicalCertificate;
               Timestamp = DateTime.UtcNow;
          }

          public string Name => nameof(UserMedicalCertificateChangedEvent);
          public object Context => this;
     }
}