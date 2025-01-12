namespace API_GruasUCAB.ServiceFee.Application.Handlers.CreateServiceFee
{
     public class CreateServiceFeeCommandHandler : IRequestHandler<CreateServiceFeeCommand, CreateServiceFeeResponseDTO>
     {
          private readonly IService<CreateServiceFeeRequestDTO, CreateServiceFeeResponseDTO> _createServiceFeeService;

          public CreateServiceFeeCommandHandler(IService<CreateServiceFeeRequestDTO, CreateServiceFeeResponseDTO> createServiceFeeService)
          {
               _createServiceFeeService = createServiceFeeService;
          }

          public async Task<CreateServiceFeeResponseDTO> Handle(CreateServiceFeeCommand request, CancellationToken cancellationToken)
          {
               return await _createServiceFeeService.Execute(request.CreateServiceFeeRequestDTO);
          }
     }
}