namespace API_GruasUCAB.ServiceFee.Application.Services.UpdateServiceFee
{
     public class UpdateServiceFeeService : IService<UpdateServiceFeeRequestDTO, UpdateServiceFeeResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly IServiceFeeFactory _serviceFeeFactory;

          public UpdateServiceFeeService(IEventStore eventStore, IServiceFeeFactory serviceFeeFactory)
          {
               _eventStore = eventStore;
               _serviceFeeFactory = serviceFeeFactory;
          }

          public async Task<UpdateServiceFeeResponseDTO> Execute(UpdateServiceFeeRequestDTO request)
          {
               var serviceFee = await _serviceFeeFactory.GetServiceFeeById(new ServiceFeeId(request.ServiceFeeId));
               if (serviceFee == null)
               {
                    throw new ServiceFeeNotFoundException(request.ServiceFeeId);
               }

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

               var domainEvents = new List<IDomainEvent>(serviceFee.GetEvents());

               await _eventStore.AppendEvents(serviceFee.Id.ToString(), domainEvents);

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