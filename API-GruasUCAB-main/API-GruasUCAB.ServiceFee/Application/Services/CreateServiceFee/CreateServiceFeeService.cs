namespace API_GruasUCAB.ServiceFee.Application.Services.CreateServiceFee
{
     public class CreateServiceFeeService : IService<CreateServiceFeeRequestDTO, CreateServiceFeeResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly IServiceFeeFactory _serviceFeeFactory;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly HeadersToken _headersToken;

          public CreateServiceFeeService(IEventStore eventStore, IServiceFeeFactory serviceFeeFactory, IKeycloakRepository keycloakRepository, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
          {
               _eventStore = eventStore;
               _serviceFeeFactory = serviceFeeFactory;
               _keycloakRepository = keycloakRepository;
               _httpClientFactory = httpClientFactory;
               _headersToken = new HeadersToken(httpContextAccessor);
          }

          public async Task<CreateServiceFeeResponseDTO> Execute(CreateServiceFeeRequestDTO request)
          {
               var token = _headersToken.GetToken();
               var client = _httpClientFactory.CreateClient();
               var (userId, role, email) = await _keycloakRepository.IntrospectTokenAsync(client, token);

               if (email != request.UserEmail || userId != request.UserId.ToString())
               {
                    throw new UnauthorizedException("Unauthorized access: token validation failed.");
               }

               if (role != "Administrador" || role != "Trabajador")
               {
                    throw new UnauthorizedException("Unauthorized access: role validation failed.");
               }

               var serviceFee = _serviceFeeFactory.CreateServiceFee(
                   new ServiceFeeId(Guid.NewGuid()),
                   new ServiceFeeName(request.Name),
                   new ServiceFeePrice(request.Price),
                   new ServiceFeePriceKm(request.PriceKm),
                   new ServiceFeeRadius(request.Radius)
               );

               List<IDomainEvent> domainEvents = new List<IDomainEvent>(serviceFee.GetEvents());
               foreach (var domainEvent in serviceFee.GetEvents())
               {
                    domainEvents.Add(domainEvent);
               }

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