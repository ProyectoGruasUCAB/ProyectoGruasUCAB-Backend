namespace API_GruasUCAB.ServiceFee.Application.Handlers.GetServiceFeeById
{
     public class GetServiceFeeByIdQueryHandler : IRequestHandler<GetServiceFeeByIdQuery, GetServiceFeeByIdResponseDTO>
     {
          private readonly IServiceFeeRepository _serviceFeeRepository;

          public GetServiceFeeByIdQueryHandler(IServiceFeeRepository serviceFeeRepository)
          {
               _serviceFeeRepository = serviceFeeRepository;
          }

          public async Task<GetServiceFeeByIdResponseDTO> Handle(GetServiceFeeByIdQuery request, CancellationToken cancellationToken)
          {
               var serviceFee = await _serviceFeeRepository.GetServiceFeeByIdAsync(request.ServiceFeeId);
               return new GetServiceFeeByIdResponseDTO { ServiceFee = serviceFee };
          }
     }
}