namespace API_GruasUCAB.Users.Domain.Events
{
     public class UserMedicalCertificateExpirationDateChangedEvent : IDomainEvent
     {
          public UserId UserId { get; }
          public UserMedicalCertificateExpirationDate NewMedicalCertificateExpirationDate { get; }
          public DateTime Timestamp { get; }
          public string DispatcherId => UserId.ToString();

          public UserMedicalCertificateExpirationDateChangedEvent(UserId userId, UserMedicalCertificateExpirationDate newMedicalCertificateExpirationDate)
          {
               if (newMedicalCertificateExpirationDate.Value < DateTime.UtcNow)
               {
                    throw new InvalidUserMedicalCertificateExpirationDateExpiredException(newMedicalCertificateExpirationDate.Value);
               }

               if (newMedicalCertificateExpirationDate.Value > DateTime.UtcNow.AddYears(10))
               {
                    throw new InvalidUserMedicalCertificateExpirationDateTooFarException(newMedicalCertificateExpirationDate.Value);
               }

               UserId = userId ?? throw new ArgumentNullException(nameof(userId), "UserId cannot be null.");
               NewMedicalCertificateExpirationDate = newMedicalCertificateExpirationDate ?? throw new ArgumentNullException(nameof(newMedicalCertificateExpirationDate), "NewMedicalCertificateExpirationDate cannot be null.");
               Timestamp = DateTime.UtcNow;
          }

          public string Name => nameof(UserMedicalCertificateExpirationDateChangedEvent);
          public object Context => this;
     }
}