namespace API_GruasUCAB.Supplier.Application.Handlers.GetSupplierByType
{
     public class GetSupplierByTypeQueryHandler : IRequestHandler<GetSupplierByTypeQuery, GetSupplierByTypeResponseDTO>
     {
          private readonly ISupplierRepository _supplierRepository;

          public GetSupplierByTypeQueryHandler(ISupplierRepository supplierRepository)
          {
               _supplierRepository = supplierRepository;
          }

          public async Task<GetSupplierByTypeResponseDTO> Handle(GetSupplierByTypeQuery request, CancellationToken cancellationToken)
          {
               var suppliers = await _supplierRepository.GetSuppliersByTypeAsync(request.Type);
               return new GetSupplierByTypeResponseDTO { Suppliers = suppliers };
          }
     }
}