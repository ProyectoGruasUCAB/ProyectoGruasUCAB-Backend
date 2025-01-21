namespace API_GruasUCAB.ServiceFee.Application.Handlers.GetServiceFeeByName
{
     public class GetServiceFeeByNameQueryHandler : IRequestHandler<GetServiceFeeByNameQuery, GetServiceFeeByNameResponseDTO>
     {
          private readonly IServiceFeeRepository _serviceFeeRepository;

          public GetServiceFeeByNameQueryHandler(IServiceFeeRepository serviceFeeRepository)
          {
               _serviceFeeRepository = serviceFeeRepository;
          }

          public async Task<GetServiceFeeByNameResponseDTO> Handle(GetServiceFeeByNameQuery request, CancellationToken cancellationToken)
          {
               var serviceFees = await _serviceFeeRepository.GetServiceFeeByNameAsync(request.Name);
               return new GetServiceFeeByNameResponseDTO { ServiceFees = serviceFees };
          }
     }
}