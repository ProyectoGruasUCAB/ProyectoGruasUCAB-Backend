namespace API_GruasUCAB.Supplier.Application.Services.CreateSupplier
{
     public class CreateSupplierService : IService<CreateSupplierRequestDTO, CreateSupplierResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly ISupplierFactory _supplierFactory;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly HeadersToken _headersToken;

          public CreateSupplierService(
              IEventStore eventStore,
              ISupplierFactory supplierFactory,
              IKeycloakRepository keycloakRepository,
              IHttpClientFactory httpClientFactory,
              IHttpContextAccessor httpContextAccessor)
          {
               _eventStore = eventStore;
               _supplierFactory = supplierFactory;
               _keycloakRepository = keycloakRepository;
               _httpClientFactory = httpClientFactory;
               _headersToken = new HeadersToken(httpContextAccessor);
          }

          public async Task<CreateSupplierResponseDTO> Execute(CreateSupplierRequestDTO request)
          {
               var token = _headersToken.GetToken();
               var client = _httpClientFactory.CreateClient();
               var (userId, role, email) = await _keycloakRepository.IntrospectTokenAsync(client, token);

               if (email != request.UserEmail || userId != request.UserId.ToString())
               {
                    throw new UnauthorizedException("Unauthorized access: token validation failed.");
               }

               if (role != "Administrador")
               {
                    throw new UnauthorizedException("Unauthorized access: role validation failed.");
               }

               if (!Enum.TryParse<SupplierTypeEnum>(request.Type, out var supplierType))
               {
                    throw new InvalidSupplierTypeException();
               }

               var supplier = _supplierFactory.CreateSupplier(
                   new SupplierId(Guid.NewGuid()),
                   new SupplierName(request.Name),
                   new SupplierType(supplierType)
               );

               var domainEvents = new List<IDomainEvent>(supplier.GetEvents());

               await _eventStore.AppendEvents(supplier.Id.ToString(), domainEvents);

               return new CreateSupplierResponseDTO
               {
                    Success = true,
                    Message = "Supplier created successfully",
                    UserEmail = request.UserEmail,
                    SupplierId = supplier.Id.Id
               };
          }
     }
}