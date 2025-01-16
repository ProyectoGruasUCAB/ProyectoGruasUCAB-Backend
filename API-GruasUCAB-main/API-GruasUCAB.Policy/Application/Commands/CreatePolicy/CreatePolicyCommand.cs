namespace API_GruasUCAB.Policy.Application.Commands.CreatePolicy
{
    public class CreatePolicyCommand : IRequest<CreatePolicyResponseDTO>
    {
        public CreatePolicyRequestDTO CreatePolicyRequestDTO { get; set; }

        public CreatePolicyCommand(CreatePolicyRequestDTO createPolicyRequestDTO)
        {
            CreatePolicyRequestDTO = createPolicyRequestDTO;
        }
    }
}