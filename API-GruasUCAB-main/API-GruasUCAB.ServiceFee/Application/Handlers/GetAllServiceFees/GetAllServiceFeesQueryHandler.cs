namespace API_GruasUCAB.ServiceFee.Application.Handlers.GetAllServiceFees
{
     public class GetAllServiceFeesQueryHandler : IRequestHandler<GetAllServiceFeesQuery, GetAllServiceFeesResponseDTO>
     {
          private readonly IServiceFeeRepository _serviceFeeRepository;

          public GetAllServiceFeesQueryHandler(IServiceFeeRepository serviceFeeRepository)
          {
               _serviceFeeRepository = serviceFeeRepository;
          }

          public async Task<GetAllServiceFeesResponseDTO> Handle(GetAllServiceFeesQuery request, CancellationToken cancellationToken)
          {
               var serviceFees = await _serviceFeeRepository.GetAllServiceFeesAsync();
               return new GetAllServiceFeesResponseDTO { ServiceFees = serviceFees };
          }
     }
}