namespace API_GruasUCAB.ServiceFee.Application.Services.CreateServiceFee
{
     public class CreateServiceFeeService : IService<CreateServiceFeeRequestDTO, CreateServiceFeeResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly IServiceFeeFactory _serviceFeeFactory;

          public CreateServiceFeeService(IEventStore eventStore, IServiceFeeFactory serviceFeeFactory)
          {
               _eventStore = eventStore;
               _serviceFeeFactory = serviceFeeFactory;
          }

          public async Task<CreateServiceFeeResponseDTO> Execute(CreateServiceFeeRequestDTO request)
          {
               var serviceFee = _serviceFeeFactory.CreateServiceFee(
                   new ServiceFeeId(Guid.NewGuid()),
                   new ServiceFeeName(request.Name),
                   new ServiceFeePrice(request.Price),
                   new ServiceFeePriceKm(request.PriceKm),
                   new ServiceFeeRadius(request.Radius)
               );

               var domainEvents = new List<IDomainEvent>(serviceFee.GetEvents());

               await _eventStore.AppendEvents(serviceFee.Id.ToString(), domainEvents);

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