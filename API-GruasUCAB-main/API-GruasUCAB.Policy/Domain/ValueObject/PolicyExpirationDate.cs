namespace API_GruasUCAB.Policy.Domain.ValueObject
{
     public class PolicyExpirationDate : ValueObject<PolicyExpirationDate>
     {
          public DateTime ExpirationDate { get; }

          public PolicyExpirationDate(string expirationDate, DateTime issueDate)
          {
               if (!DateTime.TryParseExact(expirationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
               {
                    throw new InvalidPolicyExpirationDateFormatException(expirationDate);
               }

               if (parsedDate <= issueDate)
               {
                    throw new InvalidPolicyExpirationDateException(parsedDate);
               }

               ExpirationDate = parsedDate;
          }

          public DateTime Value => ExpirationDate;

          public override bool Equals(PolicyExpirationDate other)
          {
               return ExpirationDate == other.ExpirationDate;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return ExpirationDate;
          }

          public override string ToString()
          {
               return ExpirationDate.ToString("dd-MM-yyyy");
          }
     }
}