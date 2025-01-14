namespace API_GruasUCAB.Users.Application.Handlers.GetDriverById
{
     public class GetDriverByIdQueryHandler : IRequestHandler<GetDriverByIdQuery, GetDriverByIdResponseDTO>
     {
          private readonly IDriverRepository _driverRepository;

          public GetDriverByIdQueryHandler(IDriverRepository driverRepository)
          {
               _driverRepository = driverRepository;
          }

          public async Task<GetDriverByIdResponseDTO> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
          {
               var driver = await _driverRepository.GetDriverByIdAsync(request.DriverId);
               return new GetDriverByIdResponseDTO { Driver = driver };
          }
     }
}