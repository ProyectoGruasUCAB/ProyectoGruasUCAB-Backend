namespace API_GruasUCAB.ServiceOrder.Application.Handlers.GetServiceOrderById
{
     public class GetServiceOrderByIdQueryHandler : IRequestHandler<GetServiceOrderByIdQuery, GetServiceOrderByIdResponseDTO>
     {
          private readonly IServiceOrderRepository _serviceOrderRepository;

          public GetServiceOrderByIdQueryHandler(IServiceOrderRepository serviceOrderRepository)
          {
               _serviceOrderRepository = serviceOrderRepository;
          }

          public async Task<GetServiceOrderByIdResponseDTO> Handle(GetServiceOrderByIdQuery request, CancellationToken cancellationToken)
          {
               var serviceOrder = await _serviceOrderRepository.GetServiceOrderByIdAsync(request.ServiceOrderId);
               return new GetServiceOrderByIdResponseDTO { ServiceOrder = serviceOrder };
          }
     }
}