namespace API_GruasUCAB.Policy.Application.Handlers.GetPolicyByPolicyNumber
{
     public class GetPolicyByPolicyNumberQueryHandler : IRequestHandler<GetPolicyByPolicyNumberQuery, GetPolicyByPolicyNumberResponseDTO>
     {
          private readonly IPolicyRepository _policyRepository;

          public GetPolicyByPolicyNumberQueryHandler(IPolicyRepository policyRepository)
          {
               _policyRepository = policyRepository;
          }

          public async Task<GetPolicyByPolicyNumberResponseDTO> Handle(GetPolicyByPolicyNumberQuery request, CancellationToken cancellationToken)
          {
               var policy = await _policyRepository.GetPolicyByPolicyNumberAsync(request.PolicyNumber);
               return new GetPolicyByPolicyNumberResponseDTO { Policy = policy };
          }
     }
}