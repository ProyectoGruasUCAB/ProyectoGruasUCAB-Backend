namespace API_GruasUCAB.Policy.Application.Handlers.GetPolicyById
{
     public class GetPolicyByIdQueryHandler : IRequestHandler<GetPolicyByIdQuery, GetPolicyByIdResponseDTO>
     {
          private readonly IPolicyRepository _policyRepository;

          public GetPolicyByIdQueryHandler(IPolicyRepository policyRepository)
          {
               _policyRepository = policyRepository;
          }

          public async Task<GetPolicyByIdResponseDTO> Handle(GetPolicyByIdQuery request, CancellationToken cancellationToken)
          {
               var policy = await _policyRepository.GetPolicyByIdAsync(request.PolicyId);
               return new GetPolicyByIdResponseDTO { Policy = policy };
          }
     }
}