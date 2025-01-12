namespace API_GruasUCAB.ServiceFee.Application.Services.UpdateServiceFee
{
     public class UpdateServiceFeeService : IService<UpdateServiceFeeRequestDTO, UpdateServiceFeeResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly IServiceFeeFactory _serviceFeeFactory;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly HeadersToken _headersToken;

          public UpdateServiceFeeService(IEventStore eventStore, IServiceFeeFactory serviceFeeFactory, IKeycloakRepository keycloakRepository, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
          {
               _eventStore = eventStore;
               _serviceFeeFactory = serviceFeeFactory;
               _keycloakRepository = keycloakRepository;
               _httpClientFactory = httpClientFactory;
               _headersToken = new HeadersToken(httpContextAccessor);
          }

          public async Task<UpdateServiceFeeResponseDTO> Execute(UpdateServiceFeeRequestDTO request)
          {
               var token = _headersToken.GetToken();
               var client = _httpClientFactory.CreateClient();
               var (userId, role, email) = await _keycloakRepository.IntrospectTokenAsync(client, token);

               if (email != request.UserEmail || userId != request.UserId.ToString())
               {
                    throw new UnauthorizedException("Unauthorized access: token validation failed.");
               }

               if (role != "Administrador" && role != "Trabajador")
               {
                    throw new UnauthorizedException("Unauthorized access: role validation failed.");
               }

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

               List<IDomainEvent> domainEvents = new List<IDomainEvent>(serviceFee.GetEvents());
               foreach (var domainEvent in serviceFee.GetEvents())
               {
                    domainEvents.Add(domainEvent);
               }

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