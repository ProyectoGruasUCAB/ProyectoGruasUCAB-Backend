namespace API_GruasUCAB.Supplier.Application.Services.CreateSupplier
{
     public class CreateSupplierService : IService<CreateSupplierRequestDTO, CreateSupplierResponseDTO>
     {
          private readonly ISupplierRepository _supplierRepository;
          private readonly ISupplierFactory _supplierFactory;

          public CreateSupplierService(
              ISupplierRepository supplierRepository,
              ISupplierFactory supplierFactory)
          {
               _supplierRepository = supplierRepository;
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

               var supplierDTO = new SupplierDTO
               {
                    SupplierId = supplier.Id.Id,
                    Name = supplier.Name.Value,
                    Type = supplier.Type.Value.ToString()
               };

               await _supplierRepository.AddSupplierAsync(supplierDTO);

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