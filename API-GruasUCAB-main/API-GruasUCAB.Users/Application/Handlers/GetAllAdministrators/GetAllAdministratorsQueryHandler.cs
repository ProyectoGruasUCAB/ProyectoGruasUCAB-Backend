namespace API_GruasUCAB.Users.Application.Handlers.GetAllAdministrators
{
     public class GetAllAdministratorsQueryHandler : IRequestHandler<GetAllAdministratorsQuery, GetAllAdministratorsResponseDTO>
     {
          private readonly IAdministratorRepository _administratorRepository;

          public GetAllAdministratorsQueryHandler(IAdministratorRepository administratorRepository)
          {
               _administratorRepository = administratorRepository;
          }

          public async Task<GetAllAdministratorsResponseDTO> Handle(GetAllAdministratorsQuery request, CancellationToken cancellationToken)
          {
               var administrators = await _administratorRepository.GetAllAdministratorsAsync();
               return new GetAllAdministratorsResponseDTO { Administrators = administrators };
          }
     }
}