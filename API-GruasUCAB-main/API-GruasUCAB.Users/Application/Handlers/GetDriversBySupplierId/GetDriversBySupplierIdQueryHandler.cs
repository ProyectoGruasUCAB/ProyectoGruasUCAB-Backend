namespace API_GruasUCAB.Users.Application.Handlers.GetDriversBySupplierId
{
     public class GetDriversBySupplierIdQueryHandler : IRequestHandler<GetDriversBySupplierIdQuery, GetDriversBySupplierIdResponseDTO>
     {
          private readonly IDriverRepository _driverRepository;
          private readonly IMapper _mapper;

          public GetDriversBySupplierIdQueryHandler(IDriverRepository driverRepository, IMapper mapper)
          {
               _driverRepository = driverRepository;
               _mapper = mapper;
          }

          public async Task<GetDriversBySupplierIdResponseDTO> Handle(GetDriversBySupplierIdQuery request, CancellationToken cancellationToken)
          {
               var drivers = await _driverRepository.GetDriversBySupplierIdAsync(request.SupplierId);
               var driverDTOs = _mapper.Map<List<DriverDTO>>(drivers);
               return new GetDriversBySupplierIdResponseDTO { Drivers = driverDTOs };
          }
     }
}