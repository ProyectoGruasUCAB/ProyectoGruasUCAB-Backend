namespace API_GruasUCAB.Supplier.Application.Commands.UpdateSupplier
{
     public class UpdateSupplierCommand : IRequest<UpdateSupplierResponseDTO>
     {
          public UpdateSupplierRequestDTO UpdateSupplierRequestDTO { get; set; }

          public UpdateSupplierCommand(UpdateSupplierRequestDTO updateSupplierRequestDTO)
          {
               UpdateSupplierRequestDTO = updateSupplierRequestDTO;
          }
     }
}