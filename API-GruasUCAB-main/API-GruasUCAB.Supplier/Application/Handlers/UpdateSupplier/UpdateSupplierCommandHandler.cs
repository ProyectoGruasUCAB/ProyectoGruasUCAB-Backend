namespace API_GruasUCAB.Supplier.Application.Handlers.UpdateSupplier
{
     public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, UpdateSupplierResponseDTO>
     {
          private readonly IService<UpdateSupplierRequestDTO, UpdateSupplierResponseDTO> _updateSupplierService;

          public UpdateSupplierCommandHandler(IService<UpdateSupplierRequestDTO, UpdateSupplierResponseDTO> updateSupplierService)
          {
               _updateSupplierService = updateSupplierService;
          }

          public async Task<UpdateSupplierResponseDTO> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
          {
               return await _updateSupplierService.Execute(request.UpdateSupplierRequestDTO);
          }
     }
}