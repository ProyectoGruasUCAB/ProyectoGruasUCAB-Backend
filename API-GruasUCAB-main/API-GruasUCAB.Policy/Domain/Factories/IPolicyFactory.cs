namespace API_GruasUCAB.Policy.Domain.Factories
{
     public interface IPolicyFactory
     {
          AggregateRoot.Policy CreatePolicy(
              PolicyId id,
              PolicyNumber policyNumber,
              PolicyName policyName,
              PolicyCoverageAmount policyCoverageAmount,
              PolicyCoverageKm policyCoverageKm,
              PolicyBaseAmount policyBaseAmount,
              PolicyPriceKm policyPriceKm,
              PolicyIssueDate policyIssueDate,
              PolicyExpirationDate policyExpirationDate,
              PolicyClient policyClient);

          Task<AggregateRoot.Policy> GetPolicyById(PolicyId id);
     }
}