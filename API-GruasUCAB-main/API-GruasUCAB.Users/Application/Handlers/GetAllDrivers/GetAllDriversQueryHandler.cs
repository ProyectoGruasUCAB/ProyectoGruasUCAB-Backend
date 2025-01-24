
namespace API_GruasUCAB.Users.Application.Handlers.GetAllDrivers
{
     public class GetAllDriversQueryHandler : IRequestHandler<GetAllDriversQuery, GetAllDriversResponseDTO>
     {
          private readonly IDriverRepository _driverRepository;

          public GetAllDriversQueryHandler(IDriverRepository driverRepository)
          {
               _driverRepository = driverRepository;
          }

          public async Task<GetAllDriversResponseDTO> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
          {
               var drivers = await _driverRepository.GetAllDriversAsync();
               return new GetAllDriversResponseDTO { Drivers = drivers };
          }
     }
}