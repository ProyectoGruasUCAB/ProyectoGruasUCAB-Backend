namespace API_GruasUCAB.Users.Domain.ValueObject
{
     public class UserMedicalCertificate : ValueObject<UserMedicalCertificate>
     {
          public string Certificate { get; }

          public string Value => Certificate;

          public UserMedicalCertificate(string certificate)
          {
               if (string.IsNullOrWhiteSpace(certificate))
                    throw new InvalidUserMedicalCertificateException(certificate);

               Certificate = certificate;
          }

          public override bool Equals(UserMedicalCertificate other)
          {
               return Certificate == other.Certificate;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Certificate;
          }

          public override string ToString()
          {
               return Certificate;
          }
     }
}