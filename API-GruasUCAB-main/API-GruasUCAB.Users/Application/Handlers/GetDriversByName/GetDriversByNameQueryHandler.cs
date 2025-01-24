namespace API_GruasUCAB.Users.Application.Handlers.GetDriversByName
{
     public class GetDriversByNameQueryHandler : IRequestHandler<GetDriversByNameQuery, GetDriversByNameResponseDTO>
     {
          private readonly IDriverRepository _driverRepository;

          public GetDriversByNameQueryHandler(IDriverRepository driverRepository)
          {
               _driverRepository = driverRepository;
          }

          public async Task<GetDriversByNameResponseDTO> Handle(GetDriversByNameQuery request, CancellationToken cancellationToken)
          {
               var drivers = await _driverRepository.GetDriversByNameAsync(request.Name);
               return new GetDriversByNameResponseDTO { Drivers = drivers };
          }
     }
}