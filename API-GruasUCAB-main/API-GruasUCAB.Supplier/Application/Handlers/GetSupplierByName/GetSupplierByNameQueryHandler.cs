namespace API_GruasUCAB.Supplier.Application.Handlers.GetSupplierByName
{
     public class GetSupplierByNameQueryHandler : IRequestHandler<GetSupplierByNameQuery, GetSupplierByNameResponseDTO>
     {
          private readonly ISupplierRepository _supplierRepository;
          private readonly IMapper _mapper;

          public GetSupplierByNameQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
          {
               _supplierRepository = supplierRepository;
               _mapper = mapper;
          }

          public async Task<GetSupplierByNameResponseDTO> Handle(GetSupplierByNameQuery request, CancellationToken cancellationToken)
          {
               var suppliers = await _supplierRepository.GetSuppliersByNameAsync(request.Name);
               var supplierDTOs = _mapper.Map<List<SupplierDTO>>(suppliers);
               return new GetSupplierByNameResponseDTO { Suppliers = supplierDTOs };
          }
     }
}