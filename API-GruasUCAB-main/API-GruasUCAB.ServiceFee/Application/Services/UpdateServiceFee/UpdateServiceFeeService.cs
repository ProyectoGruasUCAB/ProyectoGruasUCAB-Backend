namespace API_GruasUCAB.ServiceFee.Application.Services.UpdateServiceFee
{
     public class UpdateServiceFeeService : IService<UpdateServiceFeeRequestDTO, UpdateServiceFeeResponseDTO>
     {
          private readonly IServiceFeeRepository _serviceFeeRepository;
          private readonly IServiceFeeFactory _serviceFeeFactory;

          public UpdateServiceFeeService(IServiceFeeRepository serviceFeeRepository, IServiceFeeFactory serviceFeeFactory)
          {
               _serviceFeeRepository = serviceFeeRepository;
               _serviceFeeFactory = serviceFeeFactory;
          }

          public async Task<UpdateServiceFeeResponseDTO> Execute(UpdateServiceFeeRequestDTO request)
          {
               var serviceFeeDTO = await _serviceFeeRepository.GetServiceFeeByIdAsync(request.ServiceFeeId);
               if (serviceFeeDTO == null)
               {
                    throw new ServiceFeeNotFoundException(request.ServiceFeeId);
               }

               var serviceFee = _serviceFeeFactory.CreateServiceFee(
                   new ServiceFeeId(serviceFeeDTO.ServiceFeeId),
                   new ServiceFeeName(serviceFeeDTO.Name),
                   new ServiceFeePrice(serviceFeeDTO.Price),
                   new ServiceFeePriceKm(serviceFeeDTO.PriceKm),
                   new ServiceFeeRadius(serviceFeeDTO.Radius)
               );

               if (!string.IsNullOrEmpty(request.Name))
               {
                    serviceFee.ChangeName(new ServiceFeeName(request.Name));
               }

               if (request.Price.HasValue)
               {
                    serviceFee.ChangePrice(new ServiceFeePrice(request.Price.Value));
               }

               if (request.PriceKm.HasValue)
               {
                    serviceFee.ChangePriceKm(new ServiceFeePriceKm(request.PriceKm.Value));
               }

               if (request.Radius.HasValue)
               {
                    serviceFee.ChangeRadius(new ServiceFeeRadius(request.Radius.Value));
               }

               serviceFeeDTO.Name = serviceFee.Name.Value;
               serviceFeeDTO.Price = serviceFee.Price.Value;
               serviceFeeDTO.PriceKm = serviceFee.PriceKm.Value;
               serviceFeeDTO.Radius = serviceFee.Radius.Value;

               await _serviceFeeRepository.UpdateServiceFeeAsync(serviceFeeDTO);

               return new UpdateServiceFeeResponseDTO
               {
                    Success = true,
                    Message = "Service fee updated successfully",
                    UserEmail = request.UserEmail,
                    Time = DateTime.UtcNow,
                    ServiceFeeId = serviceFee.Id.Value,
                    Name = serviceFee.Name.Value,
                    Price = serviceFee.Price.Value,
                    PriceKm = serviceFee.PriceKm.Value,
                    Radius = serviceFee.Radius.Value
               };
          }
     }
}