namespace API_GruasUCAB.Policy.Infrastructure.Adapters.Handlers
{
     public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDTO>
     {
          private readonly IClientRepository _clientRepository;

          public GetClientByIdQueryHandler(IClientRepository clientRepository)
          {
               _clientRepository = clientRepository;
          }

          public async Task<ClientDTO> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
          {
               return await _clientRepository.GetClientByIdAsync(request.ClientId);
          }
     }
}