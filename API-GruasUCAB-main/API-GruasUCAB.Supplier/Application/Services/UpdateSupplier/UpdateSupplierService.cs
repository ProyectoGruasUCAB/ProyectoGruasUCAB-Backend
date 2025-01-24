namespace API_GruasUCAB.Supplier.Application.Services.UpdateSupplier
{
     public class UpdateSupplierService : IService<UpdateSupplierRequestDTO, UpdateSupplierResponseDTO>
     {
          private readonly ISupplierRepository _supplierRepository;
          private readonly ISupplierFactory _supplierFactory;
          private readonly IMapper _mapper;

          public UpdateSupplierService(
              ISupplierRepository supplierRepository,
              ISupplierFactory supplierFactory,
              IMapper mapper)
          {
               _supplierRepository = supplierRepository;
               _supplierFactory = supplierFactory;
               _mapper = mapper;
          }

          public async Task<UpdateSupplierResponseDTO> Execute(UpdateSupplierRequestDTO request)
          {
               var supplierDTO = await _supplierRepository.GetSupplierByIdAsync(request.SupplierId);
               if (supplierDTO == null)
               {
                    throw new SupplierNotFoundException(request.SupplierId);
               }

               var supplier = _supplierFactory.CreateSupplier(
                   new SupplierId(supplierDTO.SupplierId),
                   new SupplierName(supplierDTO.Name),
                   new SupplierType(Enum.Parse<SupplierTypeEnum>(supplierDTO.Type))
               );

               if (!string.IsNullOrEmpty(request.Name))
               {
                    supplier.ChangeName(new SupplierName(request.Name));
               }

               if (!string.IsNullOrEmpty(request.Type) && Enum.TryParse<SupplierTypeEnum>(request.Type, out var supplierType))
               {
                    supplier.ChangeType(new SupplierType(supplierType));
               }

               supplierDTO = _mapper.Map<SupplierDTO>(supplier);
               await _supplierRepository.UpdateSupplierAsync(supplierDTO);

               return new UpdateSupplierResponseDTO
               {
                    Success = true,
                    Message = "Supplier updated successfully",
                    UserEmail = request.UserEmail,
                    SupplierId = supplier.Id.Value,
                    Name = supplier.Name.Value,
                    Type = supplier.Type.Value.ToString()
               };
          }
     }
}