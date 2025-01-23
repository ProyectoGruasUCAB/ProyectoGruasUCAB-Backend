namespace API_GruasUCAB.ServiceOrder.Application.Handlers.GetOrdersByDriverId
{
     public class GetOrdersByDriverIdQueryHandler : IRequestHandler<GetOrdersByDriverIdQuery, GetOrdersByDriverIdResponseDTO>
     {
          private readonly IServiceOrderRepository _serviceOrderRepository;
          private readonly IMapper _mapper;

          public GetOrdersByDriverIdQueryHandler(IServiceOrderRepository serviceOrderRepository, IMapper mapper)
          {
               _serviceOrderRepository = serviceOrderRepository;
               _mapper = mapper;
          }

          public async Task<GetOrdersByDriverIdResponseDTO> Handle(GetOrdersByDriverIdQuery request, CancellationToken cancellationToken)
          {
               var serviceOrders = await _serviceOrderRepository.GetServiceOrdersByDriverIdAsync(request.DriverId);
               var serviceOrderDTOs = _mapper.Map<List<ServiceOrderDTO>>(serviceOrders);
               return new GetOrdersByDriverIdResponseDTO { ServiceOrders = serviceOrderDTOs };
          }
     }
}