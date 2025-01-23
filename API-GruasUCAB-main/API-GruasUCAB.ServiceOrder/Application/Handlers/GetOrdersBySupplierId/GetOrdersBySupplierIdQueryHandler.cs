namespace API_GruasUCAB.ServiceOrder.Application.Handlers.GetOrdersBySupplierId
{
     public class GetOrdersBySupplierIdQueryHandler : IRequestHandler<GetOrdersBySupplierIdQuery, GetOrdersBySupplierIdResponseDTO>
     {
          private readonly IServiceOrderRepository _serviceOrderRepository;
          private readonly IMapper _mapper;

          public GetOrdersBySupplierIdQueryHandler(IServiceOrderRepository serviceOrderRepository, IMapper mapper)
          {
               _serviceOrderRepository = serviceOrderRepository;
               _mapper = mapper;
          }

          public async Task<GetOrdersBySupplierIdResponseDTO> Handle(GetOrdersBySupplierIdQuery request, CancellationToken cancellationToken)
          {
               var serviceOrders = await _serviceOrderRepository.GetServiceOrdersBySupplierIdAsync(request.SupplierId);
               var serviceOrderDTOs = _mapper.Map<List<ServiceOrderDTO>>(serviceOrders);
               return new GetOrdersBySupplierIdResponseDTO { ServiceOrders = serviceOrderDTOs };
          }
     }
}