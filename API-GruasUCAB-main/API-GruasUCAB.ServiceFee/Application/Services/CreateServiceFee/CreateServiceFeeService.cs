namespace API_GruasUCAB.ServiceFee.Application.Services.CreateServiceFee
{
     public class CreateServiceFeeService : IService<CreateServiceFeeRequestDTO, CreateServiceFeeResponseDTO>
     {
          private readonly IServiceFeeRepository _serviceFeeRepository;
          private readonly IServiceFeeFactory _serviceFeeFactory;

          public CreateServiceFeeService(IServiceFeeRepository serviceFeeRepository, IServiceFeeFactory serviceFeeFactory)
          {
               _serviceFeeRepository = serviceFeeRepository;
               _serviceFeeFactory = serviceFeeFactory;
          }

          public async Task<CreateServiceFeeResponseDTO> Execute(CreateServiceFeeRequestDTO request)
          {
               var serviceFee = _serviceFeeFactory.CreateServiceFee(
                   new ServiceFeeId(Guid.NewGuid()),
                   new ServiceFeeName(request.Name),
                   new ServiceFeePrice(request.Price),
                   new ServiceFeePriceKm(request.PriceKm),
                   new ServiceFeeRadius(request.Radius),
                   new ServiceFeeDescription(request.Description)
               );

               var serviceFeeDTO = new ServiceFeeDTO
               {
                    ServiceFeeId = serviceFee.Id.Id,
                    Name = serviceFee.Name.Value,
                    Price = serviceFee.Price.Value,
                    PriceKm = serviceFee.PriceKm.Value,
                    Radius = serviceFee.Radius.Value,
                    Description = serviceFee.Description.Value
               };

               await _serviceFeeRepository.AddServiceFeeAsync(serviceFeeDTO);

               return new CreateServiceFeeResponseDTO
               {
                    Success = true,
                    Message = "Service fee created successfully",
                    UserEmail = request.UserEmail,
                    Time = DateTime.UtcNow,
                    ServiceFeeId = serviceFee.Id.Id
               };
          }
     }
}