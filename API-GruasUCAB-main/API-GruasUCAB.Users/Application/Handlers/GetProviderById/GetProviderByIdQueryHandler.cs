namespace API_GruasUCAB.Users.Application.Handlers.GetProviderById
{
     public class GetProviderByIdQueryHandler : IRequestHandler<GetProviderByIdQuery, GetProviderByIdResponseDTO>
     {
          private readonly IProviderRepository _providerRepository;

          public GetProviderByIdQueryHandler(IProviderRepository providerRepository)
          {
               _providerRepository = providerRepository;
          }

          public async Task<GetProviderByIdResponseDTO> Handle(GetProviderByIdQuery request, CancellationToken cancellationToken)
          {
               var provider = await _providerRepository.GetProviderByIdAsync(request.ProviderId);
               return new GetProviderByIdResponseDTO { Provider = provider };
          }
     }
}