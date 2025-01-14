namespace API_GruasUCAB.Supplier.Application.Services.UpdateSupplier
{
     public class UpdateSupplierService : IService<UpdateSupplierRequestDTO, UpdateSupplierResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly ISupplierFactory _supplierFactory;

          public UpdateSupplierService(
              IEventStore eventStore,
              ISupplierFactory supplierFactory)
          {
               _eventStore = eventStore;
               _supplierFactory = supplierFactory;
          }

          public async Task<UpdateSupplierResponseDTO> Execute(UpdateSupplierRequestDTO request)
          {
               var supplier = await _supplierFactory.GetSupplierById(new SupplierId(request.SupplierId));
               if (supplier == null)
               {
                    throw new SupplierNotFoundException(request.SupplierId);
               }

               if (!string.IsNullOrEmpty(request.Name))
               {
                    supplier.ChangeName(new SupplierName(request.Name));
               }

               if (!string.IsNullOrEmpty(request.Type) && Enum.TryParse<SupplierTypeEnum>(request.Type, out var supplierType))
               {
                    supplier.ChangeType(new SupplierType(supplierType));
               }

               var domainEvents = new List<IDomainEvent>(supplier.GetEvents());

               await _eventStore.AppendEvents(supplier.Id.ToString(), domainEvents);

               return new UpdateSupplierResponseDTO
               {
                    Success = true,
                    Message = "Supplier updated successfully",
                    UserEmail = request.UserEmail,
                    SupplierId = supplier.Id.Id,
                    Name = supplier.Name.Value,
                    Type = supplier.Type.Value.ToString()
               };
          }
     }
}