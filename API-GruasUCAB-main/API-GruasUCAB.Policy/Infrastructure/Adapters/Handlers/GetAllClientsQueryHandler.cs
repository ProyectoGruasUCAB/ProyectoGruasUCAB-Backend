namespace API_GruasUCAB.Policy.Infrastructure.Adapters.Handlers
{
     public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<ClientDTO>>
     {
          private readonly IClientRepository _clientRepository;

          public GetAllClientsQueryHandler(IClientRepository clientRepository)
          {
               _clientRepository = clientRepository;
          }

          public async Task<List<ClientDTO>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
          {
               return await _clientRepository.GetAllClientsAsync();
          }
     }
}