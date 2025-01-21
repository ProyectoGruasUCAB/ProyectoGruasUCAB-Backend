using MediatR;
using API_GruasUCAB.Policy.Infrastructure.DTOs.ClientQueries;

namespace API_GruasUCAB.Policy.Application.Queries.GetClientById
{
    public class GetClientByIdQuery : IRequest<GetClientByIdResponseDTO>
    {
        public Guid UserId { get; }
        public Guid ClientId { get; }

        public GetClientByIdQuery(Guid userId, Guid clientId)
        {
            UserId = userId;
            ClientId = clientId;
        }
    }
}