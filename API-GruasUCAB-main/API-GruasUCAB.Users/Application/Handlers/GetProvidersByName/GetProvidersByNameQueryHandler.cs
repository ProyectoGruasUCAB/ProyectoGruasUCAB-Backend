namespace API_GruasUCAB.Users.Application.Handlers.GetProvidersByName
{
     public class GetProvidersByNameQueryHandler : IRequestHandler<GetProvidersByNameQuery, GetProvidersByNameResponseDTO>
     {
          private readonly IProviderRepository _providerRepository;

          public GetProvidersByNameQueryHandler(IProviderRepository providerRepository)
          {
               _providerRepository = providerRepository;
          }

          public async Task<GetProvidersByNameResponseDTO> Handle(GetProvidersByNameQuery request, CancellationToken cancellationToken)
          {
               var providers = await _providerRepository.GetProvidersByNameAsync(request.Name);
               return new GetProvidersByNameResponseDTO { Providers = providers };
          }
     }
}