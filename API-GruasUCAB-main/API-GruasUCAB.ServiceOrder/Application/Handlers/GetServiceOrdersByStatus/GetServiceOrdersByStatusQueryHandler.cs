namespace API_GruasUCAB.ServiceOrder.Application.Handlers.GetServiceOrdersByStatus
{
     public class GetServiceOrdersByStatusQueryHandler : IRequestHandler<GetServiceOrdersByStatusQuery, GetServiceOrdersByStatusResponseDTO>
     {
          private readonly IServiceOrderRepository _serviceOrderRepository;

          public GetServiceOrdersByStatusQueryHandler(IServiceOrderRepository serviceOrderRepository)
          {
               _serviceOrderRepository = serviceOrderRepository;
          }

          public async Task<GetServiceOrdersByStatusResponseDTO> Handle(GetServiceOrdersByStatusQuery request, CancellationToken cancellationToken)
          {
               var serviceOrders = await _serviceOrderRepository.GetServiceOrdersByStatusAsync(request.Status);
               return new GetServiceOrdersByStatusResponseDTO { ServiceOrders = serviceOrders, Status = request.Status };
          }
     }
}