namespace API_GruasUCAB.ServiceFee.Application.Handlers.UpdateServiceFee
{
     public class UpdateServiceFeeCommandHandler : IRequestHandler<UpdateServiceFeeCommand, UpdateServiceFeeResponseDTO>
     {
          private readonly IService<UpdateServiceFeeRequestDTO, UpdateServiceFeeResponseDTO> _updateServiceFeeService;

          public UpdateServiceFeeCommandHandler(IService<UpdateServiceFeeRequestDTO, UpdateServiceFeeResponseDTO> updateServiceFeeService)
          {
               _updateServiceFeeService = updateServiceFeeService;
          }

          public async Task<UpdateServiceFeeResponseDTO> Handle(UpdateServiceFeeCommand request, CancellationToken cancellationToken)
          {
               return await _updateServiceFeeService.Execute(request.UpdateServiceFeeRequestDTO);
          }
     }
}