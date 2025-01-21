using MediatR;
using API_GruasUCAB.Policy.Infrastructure.DTOs.ClientQueries;

namespace API_GruasUCAB.Policy.Application.Queries.GetAllClients
{
    public class GetAllClientsQuery : IRequest<GetAllClientsResponseDTO>
    {
        public Guid UserId { get; }

        public GetAllClientsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}