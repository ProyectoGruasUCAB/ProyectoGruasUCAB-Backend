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
               return new AggregateRoot.Policy(
                   new PolicyId(policyDTO.PolicyId),
                   new PolicyNumber(policyDTO.PolicyNumber),
                   new PolicyName(policyDTO.PolicyName),
                   new PolicyCoverageAmount(policyDTO.PolicyCoverageAmount),
                   new PolicyCoverageKm(policyDTO.PolicyCoverageKm),
                   new PolicyBaseAmount(policyDTO.PolicyBaseAmount),
                   new PolicyPriceKm(policyDTO.PolicyPriceKm),
                   new PolicyIssueDate(policyDTO.PolicyIssueDate),
                   new PolicyExpirationDate(policyDTO.PolicyExpirationDate.ToString(), DateTime.ParseExact(policyDTO.PolicyIssueDate, "dd-MM-yyyy", null)),
                   new PolicyClient(policyDTO.PolicyClientId)
               );
          }
     }
}