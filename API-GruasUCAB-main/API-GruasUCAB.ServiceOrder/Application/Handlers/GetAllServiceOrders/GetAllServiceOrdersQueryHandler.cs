namespace API_GruasUCAB.ServiceOrder.Application.Handlers.GetAllServiceOrders
{
     public class GetAllServiceOrdersQueryHandler : IRequestHandler<GetAllServiceOrdersQuery, GetAllServiceOrdersResponseDTO>
     {
          private readonly IServiceOrderRepository _serviceOrderRepository;

          public GetAllServiceOrdersQueryHandler(IServiceOrderRepository serviceOrderRepository)
          {
               _serviceOrderRepository = serviceOrderRepository;
          }

          public async Task<GetAllServiceOrdersResponseDTO> Handle(GetAllServiceOrdersQuery request, CancellationToken cancellationToken)
          {
               var serviceOrders = await _serviceOrderRepository.GetAllServiceOrdersAsync();
               return new GetAllServiceOrdersResponseDTO { ServiceOrders = serviceOrders };
          }
     }
}