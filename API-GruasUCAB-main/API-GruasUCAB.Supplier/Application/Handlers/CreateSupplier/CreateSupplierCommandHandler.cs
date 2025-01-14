namespace API_GruasUCAB.Supplier.Application.Handlers.CreateSupplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, CreateSupplierResponseDTO>
    {
        private readonly IService<CreateSupplierRequestDTO, CreateSupplierResponseDTO> _createSupplierService;

        public CreateSupplierCommandHandler(IService<CreateSupplierRequestDTO, CreateSupplierResponseDTO> createSupplierService)
        {
            _createSupplierService = createSupplierService;
        }

        public async Task<CreateSupplierResponseDTO> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            return await _createSupplierService.Execute(request.CreateSupplierRequestDTO);
        }
    }
}