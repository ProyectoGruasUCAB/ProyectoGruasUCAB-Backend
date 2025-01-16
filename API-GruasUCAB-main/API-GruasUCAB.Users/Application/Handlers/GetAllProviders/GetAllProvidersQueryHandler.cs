namespace API_GruasUCAB.Users.Application.Handlers.GetAllProviders
{
     public class GetAllProvidersQueryHandler : IRequestHandler<GetAllProvidersQuery, GetAllProvidersResponseDTO>
     {
          private readonly IProviderRepository _providerRepository;

          public GetAllProvidersQueryHandler(IProviderRepository providerRepository)
          {
               _providerRepository = providerRepository;
          }

          public async Task<GetAllProvidersResponseDTO> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
          {
               var providers = await _providerRepository.GetAllProvidersAsync();
               return new GetAllProvidersResponseDTO { Providers = providers };
          }
     }
}