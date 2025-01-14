namespace API_GruasUCAB.Supplier.Application.Services.CreateSupplier
{
     public class CreateSupplierService : IService<CreateSupplierRequestDTO, CreateSupplierResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly ISupplierFactory _supplierFactory;

          public CreateSupplierService(
              IEventStore eventStore,
              ISupplierFactory supplierFactory)
          {
               _eventStore = eventStore;
               _supplierFactory = supplierFactory;
          }

          public async Task<CreateSupplierResponseDTO> Execute(CreateSupplierRequestDTO request)
          {
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