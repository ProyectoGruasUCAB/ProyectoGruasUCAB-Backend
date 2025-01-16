namespace API_GruasUCAB.Policy.Domain.ValueObject
{
     public class PolicyIssueDate : ValueObject<PolicyIssueDate>
     {
          public DateTime IssueDate { get; }

          public PolicyIssueDate(string issueDate)
          {
               if (!DateTime.TryParseExact(issueDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
               {
                    throw new InvalidPolicyIssueDateFormatException(issueDate);
               }

               IssueDate = parsedDate;
          }

          public DateTime Value => IssueDate;

          public override bool Equals(PolicyIssueDate other)
          {
               return IssueDate == other.IssueDate;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return IssueDate;
          }

          public override string ToString()
          {
               return IssueDate.ToString("dd-MM-yyyy");
          }
     }
}