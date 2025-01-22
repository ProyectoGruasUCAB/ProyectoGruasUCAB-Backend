namespace API_GruasUCAB.Policy.Application.Services.CreatePolicy
{
     public class CreatePolicyService : IService<CreatePolicyRequestDTO, CreatePolicyResponseDTO>
     {
          private readonly IPolicyRepository _policyRepository;
          private readonly IPolicyFactory _policyFactory;
          private readonly IClientRepository _clientRepository;

          public CreatePolicyService(IPolicyRepository policyRepository, IPolicyFactory policyFactory, IClientRepository clientRepository)
          {
               _policyRepository = policyRepository;
               _policyFactory = policyFactory;
               _clientRepository = clientRepository;
          }

          public async Task<CreatePolicyResponseDTO> Execute(CreatePolicyRequestDTO request)
          {
               // Validar que el cliente exista
               var client = await _clientRepository.GetClientByIdAsync(request.ClientId);
               if (client == null)
               {
                    return new CreatePolicyResponseDTO
                    {
                         Success = false,
                         Message = "Client does not exist",
                         UserEmail = request.UserEmail
                    };
               }

               var random = new Random();
               var policyNumber = random.Next(1000, 9999).ToString();

               var issueDate = new PolicyIssueDate(DateTime.UtcNow.ToString("dd-MM-yyyy"));
               var expirationDate = new PolicyExpirationDate(issueDate.Value.AddYears(1).ToString("dd-MM-yyyy"), issueDate.Value);

               var policy = _policyFactory.CreatePolicy(
                   new PolicyId(Guid.NewGuid()),
                   new PolicyNumber(policyNumber),
                   new PolicyName(request.Name),
                   new PolicyCoverageAmount(request.CoverageAmount),
                   new PolicyCoverageKm(request.CoverageKm),
                   new PolicyBaseAmount(request.BaseAmount),
                   new PolicyPriceKm(request.PriceKm),
                   issueDate,
                   expirationDate,
                   new PolicyClient(request.ClientId)
               );

               var policyDTO = new PolicyDTO
               {
                    PolicyId = policy.Id.Id,
                    Number = policy.PolicyNumber.Value,
                    Name = policy.PolicyName.Value,
                    CoverageAmount = policy.PolicyCoverageAmount.Value,
                    CoverageKm = policy.PolicyCoverageKm.Value,
                    BaseAmount = policy.PolicyBaseAmount.Value,
                    PriceKm = policy.PolicyPriceKm.Value,
                    IssueDate = policy.PolicyIssueDate.Value.ToString("dd-MM-yyyy"),
                    ExpirationDate = policy.PolicyExpirationDate.Value.ToString("dd-MM-yyyy"),
                    ClientId = policy.PolicyClient.Value
               };

               await _policyRepository.AddPolicyAsync(policyDTO);

               return new CreatePolicyResponseDTO
               {
                    Success = true,
                    Message = "Policy created successfully",
                    UserEmail = request.UserEmail,
                    PolicyId = policy.Id.Id
               };
          }
     }
}