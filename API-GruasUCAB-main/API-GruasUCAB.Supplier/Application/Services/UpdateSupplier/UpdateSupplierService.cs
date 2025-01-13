namespace API_GruasUCAB.Supplier.Application.Services.UpdateSupplier
{
     public class UpdateSupplierService : IService<UpdateSupplierRequestDTO, UpdateSupplierResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly ISupplierFactory _SupplierFactory;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly HeadersToken _headersToken;

          public UpdateSupplierService(IEventStore eventStore, ISupplierFactory SupplierFactory, IKeycloakRepository keycloakRepository, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
          {
               _eventStore = eventStore;
               _SupplierFactory = SupplierFactory;
               _keycloakRepository = keycloakRepository;
               _httpClientFactory = httpClientFactory;
               _headersToken = new HeadersToken(httpContextAccessor);
          }

          public async Task<UpdateSupplierResponseDTO> Execute(UpdateSupplierRequestDTO request)
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

               var Supplier = await _SupplierFactory.GetSupplierById(new SupplierId(request.SupplierId));
               if (Supplier == null)
               {
                    throw new SupplierNotFoundException(request.SupplierId);
               }

               if (!string.IsNullOrEmpty(request.Name))
               {
                    Supplier.ChangeName(new SupplierName(request.Name));
               }

               if (!string.IsNullOrEmpty(request.Type) && Enum.TryParse<SupplierTypeEnum>(request.Type, out var supplierType))
               {
                    Supplier.ChangeType(new SupplierType(supplierType));
               }

               List<IDomainEvent> domainEvents = new List<IDomainEvent>(Supplier.GetEvents());
               foreach (var domainEvent in Supplier.GetEvents())
               {
                    domainEvents.Add(domainEvent);
               }

               await _eventStore.AppendEvents(Supplier.Id.ToString(), domainEvents);

               return new UpdateSupplierResponseDTO
               {
                    Success = true,
                    Message = "Supplier updated successfully",
                    UserEmail = request.UserEmail,
                    SupplierId = Supplier.Id.Id,
                    Name = Supplier.Name.Value,
                    Type = Supplier.Type.Value.ToString()
               };
          }
     }
}