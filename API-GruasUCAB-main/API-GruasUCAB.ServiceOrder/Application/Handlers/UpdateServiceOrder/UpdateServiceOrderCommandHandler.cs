namespace API_GruasUCAB.ServiceOrder.Application.Handlers.UpdateServiceOrder
{
     public class UpdateServiceOrderCommandHandler : IRequestHandler<UpdateServiceOrderCommand, UpdateServiceOrderResponseDTO>
     {
          private readonly IService<UpdateServiceOrderRequestDTO, UpdateServiceOrderResponseDTO> _updateServiceOrderService;

          public UpdateServiceOrderCommandHandler(IService<UpdateServiceOrderRequestDTO, UpdateServiceOrderResponseDTO> updateServiceOrderService)
          {
               _updateServiceOrderService = updateServiceOrderService;
          }

          public async Task<UpdateServiceOrderResponseDTO> Handle(UpdateServiceOrderCommand request, CancellationToken cancellationToken)
          {
               return await _updateServiceOrderService.Execute(request.UpdateServiceOrderRequestDTO);
          }
     }
}