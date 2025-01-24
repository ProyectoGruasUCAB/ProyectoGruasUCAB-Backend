namespace API_GruasUCAB.ServiceOrder.Application.Handlers.GetOrdersByOperatorId
{
     public class GetOrdersByOperatorIdQueryHandler : IRequestHandler<GetOrdersByOperatorIdQuery, GetOrdersByOperatorIdResponseDTO>
     {
          private readonly IServiceOrderRepository _serviceOrderRepository;
          private readonly IMapper _mapper;

          public GetOrdersByOperatorIdQueryHandler(IServiceOrderRepository serviceOrderRepository, IMapper mapper)
          {
               _serviceOrderRepository = serviceOrderRepository;
               _mapper = mapper;
          }

          public async Task<GetOrdersByOperatorIdResponseDTO> Handle(GetOrdersByOperatorIdQuery request, CancellationToken cancellationToken)
          {
               var serviceOrders = await _serviceOrderRepository.GetServiceOrdersByOperatorIdAsync(request.OperatorId);
               var serviceOrderDTOs = _mapper.Map<List<ServiceOrderDTO>>(serviceOrders);
               return new GetOrdersByOperatorIdResponseDTO { ServiceOrders = serviceOrderDTOs };
          }
     }
}