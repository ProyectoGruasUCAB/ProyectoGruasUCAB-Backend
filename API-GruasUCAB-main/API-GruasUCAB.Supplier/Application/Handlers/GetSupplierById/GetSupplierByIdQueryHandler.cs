namespace API_GruasUCAB.Supplier.Application.Handlers.GetSupplierById
{
     public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, GetSupplierByIdResponseDTO>
     {
          private readonly ISupplierRepository _supplierRepository;

          public GetSupplierByIdQueryHandler(ISupplierRepository supplierRepository)
          {
               _supplierRepository = supplierRepository;
          }

          public async Task<GetSupplierByIdResponseDTO> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
          {
               var supplier = await _supplierRepository.GetSupplierByIdAsync(request.SupplierId);
               return new GetSupplierByIdResponseDTO { Supplier = supplier };
          }
     }
}