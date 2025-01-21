using API_GruasUCAB.Policy.Infrastructure.DTOs.CreateClient;
using MediatR;

namespace API_GruasUCAB.Policy.Application.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<CreateClientResponseDTO>
    {
        public CreateClientRequestDTO CreateClientRequestDTO { get; set; }

        public CreateClientCommand(CreateClientRequestDTO createClientRequestDTO)
        {
            CreateClientRequestDTO = createClientRequestDTO;
        }
    }
}