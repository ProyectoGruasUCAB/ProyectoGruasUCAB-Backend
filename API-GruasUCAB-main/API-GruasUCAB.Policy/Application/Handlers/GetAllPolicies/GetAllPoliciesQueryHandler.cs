namespace API_GruasUCAB.Policy.Application.Handlers.GetAllPolicies
{
     public class GetAllPoliciesQueryHandler : IRequestHandler<GetAllPoliciesQuery, GetAllPoliciesResponseDTO>
     {
          private readonly IPolicyRepository _policyRepository;

          public GetAllPoliciesQueryHandler(IPolicyRepository policyRepository)
          {
               _policyRepository = policyRepository;
          }

          public async Task<GetAllPoliciesResponseDTO> Handle(GetAllPoliciesQuery request, CancellationToken cancellationToken)
          {
               var policies = await _policyRepository.GetAllPoliciesAsync();
               return new GetAllPoliciesResponseDTO { Policies = policies };
          }
     }
}