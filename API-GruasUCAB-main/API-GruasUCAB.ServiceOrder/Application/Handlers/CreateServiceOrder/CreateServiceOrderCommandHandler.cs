namespace API_GruasUCAB.ServiceOrder.Application.Handlers.CreateServiceOrder
{
     public class CreateServiceOrderCommandHandler : IRequestHandler<CreateServiceOrderCommand, CreateServiceOrderResponseDTO>
     {
          private readonly IService<CreateServiceOrderRequestDTO, CreateServiceOrderResponseDTO> _createServiceOrderService;

          public CreateServiceOrderCommandHandler(IService<CreateServiceOrderRequestDTO, CreateServiceOrderResponseDTO> createServiceOrderService)
          {
               _createServiceOrderService = createServiceOrderService;
          }

          public async Task<CreateServiceOrderResponseDTO> Handle(CreateServiceOrderCommand request, CancellationToken cancellationToken)
          {
               return await _createServiceOrderService.Execute(request.CreateServiceOrderRequestDTO);
          }
     }
}