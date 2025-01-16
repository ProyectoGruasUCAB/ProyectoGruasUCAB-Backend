namespace API_GruasUCAB.Policy.Application.Services.CreatePolicy
{
     public class CreatePolicyService : IService<CreatePolicyRequestDTO, CreatePolicyResponseDTO>
     {
          private readonly IPolicyRepository _policyRepository;
          private readonly IPolicyFactory _policyFactory;

          public CreatePolicyService(IPolicyRepository policyRepository, IPolicyFactory policyFactory)
          {
               _policyRepository = policyRepository;
               _policyFactory = policyFactory;
          }

          public async Task<CreatePolicyResponseDTO> Execute(CreatePolicyRequestDTO request)
          {
               var policy = _policyFactory.CreatePolicy(
                   new PolicyId(Guid.NewGuid()),
                   new PolicyNumber(request.PolicyNumber),
                   new PolicyName(request.PolicyName),
                   new PolicyCoverageAmount(request.PolicyCoverageAmount),
                   new PolicyCoverageKm(request.PolicyCoverageKm),
                   new PolicyBaseAmount(request.PolicyBaseAmount),
                   new PolicyPriceKm(request.PolicyPriceKm),
                   new PolicyIssueDate(request.PolicyIssueDate),
                   new PolicyExpirationDate(request.PolicyExpirationDate, DateTime.ParseExact(request.PolicyIssueDate, "dd-MM-yyyy", null)),
                   new PolicyClient(request.PolicyClientId)
               );

               var policyDTO = new PolicyDTO
               {
                    PolicyId = policy.Id.Id,
                    PolicyNumber = policy.PolicyNumber.Value,
                    PolicyName = policy.PolicyName.Value,
                    PolicyCoverageAmount = policy.PolicyCoverageAmount.Value,
                    PolicyCoverageKm = policy.PolicyCoverageKm.Value,
                    PolicyBaseAmount = policy.PolicyBaseAmount.Value,
                    PolicyPriceKm = policy.PolicyPriceKm.Value,
                    PolicyIssueDate = policy.PolicyIssueDate.Value.ToString("dd-MM-yyyy"),
                    PolicyExpirationDate = policy.PolicyExpirationDate.Value.ToString("dd-MM-yyyy"),
                    PolicyClientId = policy.PolicyClient.Value
               };

               await _policyRepository.AddPolicyAsync(policyDTO);

               return new CreatePolicyResponseDTO
               {
                    Success = true,
                    Message = "Policy created successfully",
                    PolicyId = policy.Id.Id
               };
          }
     }
}