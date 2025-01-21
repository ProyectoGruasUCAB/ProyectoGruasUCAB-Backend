namespace API_GruasUCAB.Vehicle.Application.Handlers.CreateVehicleType
{
     public class CreateVehicleTypeCommandHandler : IRequestHandler<CreateVehicleTypeCommand, CreateVehicleTypeResponseDTO>
     {
          private readonly IService<CreateVehicleTypeRequestDTO, CreateVehicleTypeResponseDTO> _createVehicleTypeService;

          public CreateVehicleTypeCommandHandler(IService<CreateVehicleTypeRequestDTO, CreateVehicleTypeResponseDTO> createVehicleTypeService)
          {
               _createVehicleTypeService = createVehicleTypeService;
          }

          public async Task<CreateVehicleTypeResponseDTO> Handle(CreateVehicleTypeCommand request, CancellationToken cancellationToken)
          {
               return await _createVehicleTypeService.Execute(request.CreateVehicleTypeRequestDTO);
          }
     }
}