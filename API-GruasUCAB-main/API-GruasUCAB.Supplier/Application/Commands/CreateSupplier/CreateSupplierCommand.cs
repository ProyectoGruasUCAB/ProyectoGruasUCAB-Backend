namespace API_GruasUCAB.Supplier.Application.Commands.CreateSupplier
{
    public class CreateSupplierCommand : IRequest<CreateSupplierResponseDTO>
    {
        public CreateSupplierRequestDTO CreateSupplierRequestDTO { get; set; }

        public CreateSupplierCommand(CreateSupplierRequestDTO createSupplierRequestDTO)
        {
            CreateSupplierRequestDTO = createSupplierRequestDTO;
        }
    }
}