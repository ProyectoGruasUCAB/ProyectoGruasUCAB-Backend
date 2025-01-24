namespace API_GruasUCAB.Vehicle.Application.Handlers.UpdateVehicle
{
     public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, UpdateVehicleResponseDTO>
     {
          private readonly IService<UpdateVehicleRequestDTO, UpdateVehicleResponseDTO> _updateVehicleService;

          public UpdateVehicleCommandHandler(IService<UpdateVehicleRequestDTO, UpdateVehicleResponseDTO> updateVehicleService)
          {
               _updateVehicleService = updateVehicleService;
          }

          public async Task<UpdateVehicleResponseDTO> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
          {
               return await _updateVehicleService.Execute(request.UpdateVehicleRequestDTO);
          }
     }
}