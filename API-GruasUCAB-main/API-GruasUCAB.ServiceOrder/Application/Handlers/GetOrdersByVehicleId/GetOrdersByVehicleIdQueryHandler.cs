namespace API_GruasUCAB.ServiceOrder.Application.Handlers.GetOrdersByVehicleId
{
     public class GetOrdersByVehicleIdQueryHandler : IRequestHandler<GetOrdersByVehicleIdQuery, GetOrdersByVehicleIdResponseDTO>
     {
          private readonly IServiceOrderRepository _serviceOrderRepository;
          private readonly IMapper _mapper;

          public GetOrdersByVehicleIdQueryHandler(IServiceOrderRepository serviceOrderRepository, IMapper mapper)
          {
               _serviceOrderRepository = serviceOrderRepository;
               _mapper = mapper;
          }

          public async Task<GetOrdersByVehicleIdResponseDTO> Handle(GetOrdersByVehicleIdQuery request, CancellationToken cancellationToken)
          {
               var serviceOrders = await _serviceOrderRepository.GetServiceOrdersByVehicleIdAsync(request.VehicleId);
               var serviceOrderDTOs = _mapper.Map<List<ServiceOrderDTO>>(serviceOrders);
               return new GetOrdersByVehicleIdResponseDTO { ServiceOrders = serviceOrderDTOs };
          }
     }
}