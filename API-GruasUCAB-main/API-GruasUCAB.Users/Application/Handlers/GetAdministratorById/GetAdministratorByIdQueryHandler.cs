namespace API_GruasUCAB.Users.Application.Handlers.GetAdministratorById
{
     public class GetAdministratorByIdQueryHandler : IRequestHandler<GetAdministratorByIdQuery, GetAdministratorByIdResponseDTO>
     {
          private readonly IAdministratorRepository _administratorRepository;

          public GetAdministratorByIdQueryHandler(IAdministratorRepository administratorRepository)
          {
               _administratorRepository = administratorRepository;
          }

          public async Task<GetAdministratorByIdResponseDTO> Handle(GetAdministratorByIdQuery request, CancellationToken cancellationToken)
          {
               var administrator = await _administratorRepository.GetAdministratorByIdAsync(request.AdministratorId);
               return new GetAdministratorByIdResponseDTO { Administrator = administrator };
          }
     }
}