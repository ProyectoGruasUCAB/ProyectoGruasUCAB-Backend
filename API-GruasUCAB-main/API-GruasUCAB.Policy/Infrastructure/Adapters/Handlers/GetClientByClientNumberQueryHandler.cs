namespace API_GruasUCAB.Policy.Infrastructure.Adapters.Handlers
{
     public class GetClientByClientNumberQueryHandler : IRequestHandler<GetClientByClientNumberQuery, ClientDTO>
     {
          private readonly IClientRepository _clientRepository;

          public GetClientByClientNumberQueryHandler(IClientRepository clientRepository)
          {
               _clientRepository = clientRepository;
          }

          public async Task<ClientDTO> Handle(GetClientByClientNumberQuery request, CancellationToken cancellationToken)
          {
               return await _clientRepository.GetClientByClientNumberAsync(request.ClientNumber);
          }
     }
}