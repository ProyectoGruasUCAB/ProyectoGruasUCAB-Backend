namespace API_GruasUCAB.Policy.Application.Handlers.CreatePolicy
{
    public class CreatePolicyCommandHandler : IRequestHandler<CreatePolicyCommand, CreatePolicyResponseDTO>
    {
        private readonly IService<CreatePolicyRequestDTO, CreatePolicyResponseDTO> _createPolicyService;

        public CreatePolicyCommandHandler(IService<CreatePolicyRequestDTO, CreatePolicyResponseDTO> createPolicyService)
        {
            _createPolicyService = createPolicyService;
        }

        public async Task<CreatePolicyResponseDTO> Handle(CreatePolicyCommand request, CancellationToken cancellationToken)
        {
            return await _createPolicyService.Execute(request.CreatePolicyRequestDTO);
        }
    }
}