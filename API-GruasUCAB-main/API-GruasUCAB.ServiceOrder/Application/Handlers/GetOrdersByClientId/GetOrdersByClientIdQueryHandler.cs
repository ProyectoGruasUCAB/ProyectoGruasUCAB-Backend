namespace API_GruasUCAB.ServiceOrder.Application.Handlers.GetOrdersByClientId
{
     public class GetOrdersByClientIdQueryHandler : IRequestHandler<GetOrdersByClientIdQuery, GetOrdersByClientIdResponseDTO>
     {
          private readonly IServiceOrderRepository _serviceOrderRepository;
          private readonly IMapper _mapper;

          public GetOrdersByClientIdQueryHandler(IServiceOrderRepository serviceOrderRepository, IMapper mapper)
          {
               _serviceOrderRepository = serviceOrderRepository;
               _mapper = mapper;
          }

          public async Task<GetOrdersByClientIdResponseDTO> Handle(GetOrdersByClientIdQuery request, CancellationToken cancellationToken)
          {
               var serviceOrders = await _serviceOrderRepository.GetServiceOrdersByClientIdAsync(request.ClientId);
               var serviceOrderDTOs = _mapper.Map<List<ServiceOrderDTO>>(serviceOrders);
               return new GetOrdersByClientIdResponseDTO { ServiceOrders = serviceOrderDTOs };
          }
     }
}