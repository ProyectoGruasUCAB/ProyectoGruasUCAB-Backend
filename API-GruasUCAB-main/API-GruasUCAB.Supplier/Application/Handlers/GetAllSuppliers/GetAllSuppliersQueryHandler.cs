namespace API_GruasUCAB.Supplier.Application.Handlers.GetAllSuppliers
{
     public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, GetAllSuppliersResponseDTO>
     {
          private readonly ISupplierRepository _supplierRepository;

          public GetAllSuppliersQueryHandler(ISupplierRepository supplierRepository)
          {
               _supplierRepository = supplierRepository;
          }

          public async Task<GetAllSuppliersResponseDTO> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
          {
               var suppliers = await _supplierRepository.GetAllSuppliersAsync();
               return new GetAllSuppliersResponseDTO { Suppliers = suppliers };
          }
     }
}