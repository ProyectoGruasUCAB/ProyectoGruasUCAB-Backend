namespace API_GruasUCAB.Policy.Infrastructure.Adapters.Queries
{
     public class GetClientByIdQuery : IRequest<ClientDTO>
     {
          public Guid ClientId { get; }

          public GetClientByIdQuery(Guid clientId)
          {
               ClientId = clientId;
          }
     }
}