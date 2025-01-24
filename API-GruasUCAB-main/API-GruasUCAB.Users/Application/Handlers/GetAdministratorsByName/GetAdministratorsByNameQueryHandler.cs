namespace API_GruasUCAB.Users.Application.Handlers.GetAdministratorsByName
{
     public class GetAdministratorsByNameQueryHandler : IRequestHandler<GetAdministratorsByNameQuery, GetAdministratorsByNameResponseDTO>
     {
          private readonly IAdministratorRepository _administratorRepository;

          public GetAdministratorsByNameQueryHandler(IAdministratorRepository administratorRepository)
          {
               _administratorRepository = administratorRepository;
          }

          public async Task<GetAdministratorsByNameResponseDTO> Handle(GetAdministratorsByNameQuery request, CancellationToken cancellationToken)
          {
               var administrators = await _administratorRepository.GetAdministratorsByNameAsync(request.Name);
               return new GetAdministratorsByNameResponseDTO { Administrators = administrators };
          }
     }
}