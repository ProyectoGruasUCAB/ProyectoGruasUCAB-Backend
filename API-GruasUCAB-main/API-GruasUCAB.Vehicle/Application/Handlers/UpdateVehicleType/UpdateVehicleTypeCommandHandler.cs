namespace API_GruasUCAB.Vehicle.Application.Handlers.UpdateVehicleType
{
     public class UpdateVehicleTypeCommandHandler : IRequestHandler<UpdateVehicleTypeCommand, UpdateVehicleTypeResponseDTO>
     {
          private readonly IService<UpdateVehicleTypeRequestDTO, UpdateVehicleTypeResponseDTO> _updateVehicleTypeService;

          public UpdateVehicleTypeCommandHandler(IService<UpdateVehicleTypeRequestDTO, UpdateVehicleTypeResponseDTO> updateVehicleTypeService)
          {
               _updateVehicleTypeService = updateVehicleTypeService;
          }

          public async Task<UpdateVehicleTypeResponseDTO> Handle(UpdateVehicleTypeCommand request, CancellationToken cancellationToken)
          {
               return await _updateVehicleTypeService.Execute(request.UpdateVehicleTypeRequestDTO);
          }
     }
}