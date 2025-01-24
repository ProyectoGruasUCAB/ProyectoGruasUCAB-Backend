namespace API_GruasUCAB.Policy.Domain.Factories
{
     public class PolicyFactory : IPolicyFactory
     {
          private readonly IPolicyRepository _policyRepository;

          public PolicyFactory(IPolicyRepository policyRepository)
          {
               _policyRepository = policyRepository;
          }

          public AggregateRoot.Policy CreatePolicy(
              PolicyId id,
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
               return new AggregateRoot.Policy(id, policyNumber, policyName, policyCoverageAmount, policyCoverageKm, policyBaseAmount, policyPriceKm, policyIssueDate, policyExpirationDate, policyClient);
          }

          public async Task<AggregateRoot.Policy> GetPolicyById(PolicyId id)
          {
               var policyDTO = await _policyRepository.GetPolicyByIdAsync(id.Id);
               var issueDate = new PolicyIssueDate(policyDTO.IssueDate);
               return new AggregateRoot.Policy(
                   new PolicyId(policyDTO.PolicyId),
                   new PolicyNumber(policyDTO.Number),
                   new PolicyName(policyDTO.Name),
                   new PolicyCoverageAmount(policyDTO.CoverageAmount),
                   new PolicyCoverageKm(policyDTO.CoverageKm),
                   new PolicyBaseAmount(policyDTO.BaseAmount),
                   new PolicyPriceKm(policyDTO.PriceKm),
                   issueDate,
                   new PolicyExpirationDate(policyDTO.ExpirationDate, issueDate.Value),
                   new PolicyClient(policyDTO.ClientId)
               );
          }
     }
}