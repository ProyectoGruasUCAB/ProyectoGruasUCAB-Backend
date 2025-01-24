namespace API_GruasUCAB.Policy.Domain.Events
{
     public class PolicyCreatedEvent : IDomainEvent
     {
          public PolicyId PolicyId { get; }
          public PolicyNumber PolicyNumber { get; }
          public PolicyName PolicyName { get; }
          public PolicyCoverageAmount PolicyCoverageAmount { get; }
          public PolicyCoverageKm PolicyCoverageKm { get; }
          public PolicyBaseAmount PolicyBaseAmount { get; }
          public PolicyPriceKm PolicyPriceKm { get; }
          public PolicyIssueDate PolicyIssueDate { get; }
          public PolicyExpirationDate PolicyExpirationDate { get; }
          public PolicyClient PolicyClient { get; }
          public DateTime Timestamp { get; }

          public PolicyCreatedEvent(
              PolicyId policyId,
              PolicyNumber policyNumber,
              PolicyName policyName,
              PolicyCoverageAmount policyCoverageAmount,
              PolicyCoverageKm policyCoverageKm,
              PolicyBaseAmount policyBaseAmount,
              PolicyPriceKm policyPriceKm,
              PolicyIssueDate policyIssueDate,
              PolicyExpirationDate policyExpirationDate,
              PolicyClient policyClient)
          {
               PolicyId = policyId ?? throw new ArgumentNullException(nameof(policyId));
               PolicyNumber = policyNumber ?? throw new ArgumentNullException(nameof(policyNumber));
               PolicyName = policyName ?? throw new ArgumentNullException(nameof(policyName));
               PolicyCoverageAmount = policyCoverageAmount ?? throw new ArgumentNullException(nameof(policyCoverageAmount));
               PolicyCoverageKm = policyCoverageKm ?? throw new ArgumentNullException(nameof(policyCoverageKm));
               PolicyBaseAmount = policyBaseAmount ?? throw new ArgumentNullException(nameof(policyBaseAmount));
               PolicyPriceKm = policyPriceKm ?? throw new ArgumentNullException(nameof(policyPriceKm));
               PolicyIssueDate = policyIssueDate ?? throw new ArgumentNullException(nameof(policyIssueDate));
               PolicyExpirationDate = policyExpirationDate ?? throw new ArgumentNullException(nameof(policyExpirationDate));
               PolicyClient = policyClient ?? throw new ArgumentNullException(nameof(policyClient));
               Timestamp = DateTime.UtcNow;
          }

          public string DispatcherId => PolicyId.ToString();
          public string Name => nameof(PolicyCreatedEvent);
          public object Context => this;
     }
}