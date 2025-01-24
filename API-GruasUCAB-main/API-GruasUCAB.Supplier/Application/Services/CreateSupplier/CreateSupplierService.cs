namespace API_GruasUCAB.Supplier.Application.Services.CreateSupplier
{
     public class CreateSupplierService : IService<CreateSupplierRequestDTO, CreateSupplierResponseDTO>
     {
          private readonly ISupplierRepository _supplierRepository;
          private readonly ISupplierFactory _supplierFactory;
          private readonly IMapper _mapper;

          public CreateSupplierService(
              ISupplierRepository supplierRepository,
              ISupplierFactory supplierFactory,
              IMapper mapper)
          {
               _supplierRepository = supplierRepository;
               _supplierFactory = supplierFactory;
               _mapper = mapper;
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

               var supplierDTO = _mapper.Map<SupplierDTO>(supplier);
               await _supplierRepository.AddSupplierAsync(supplierDTO);

               return new CreateSupplierResponseDTO
               {
                    Success = true,
                    Message = "Supplier created successfully",
                    UserEmail = request.UserEmail,
                    SupplierId = supplier.Id.Value
               };
          }
     }
}